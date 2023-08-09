using IsSistemReservation.App.Core.Services.Table;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Services.Reservation
{
	public class ReservationService : IReservationService
	{
		private IUnitOfWork _unitOfWork;
		private readonly ILogger<ReservationService> _logger;
		public ReservationService(IUnitOfWork unitOfWork, ILogger<ReservationService> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<BaseResponseResult> CreateReservation(ReservationRequestDto request)
		{
			var response = new BaseResponseResult();

			try
			{
				var getCustomer = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(a => a.Id == request.CustomerId);
				if (getCustomer == null)
				{
					response.Errors.Add(ResponseMessageConstants.NoRecordCustomer);
					return response;
				}

				var getReservation = await _unitOfWork.ReservationRepository.FirstOrDefaultAsync(a => a.CustomerId == request.CustomerId && a.ReservationDate.Day == request.ReservationDate.Day && a.IsActive);
				if (getReservation != null)
				{
					response.Errors.Add(ResponseMessageConstants.AllreadyRecordData);
					return response;
				}

				var getAvailable = await _unitOfWork.TableRepository.Table.Include(a => a.Reservations).Where(a => !a.Reservations.Any(c => c.ReservationDate.Date == request.ReservationDate.Date && !c.IsDeleted && c.IsActive) && a.Capacity >= request.NumberOfGuests && a.IsActive && !a.IsDeleted).OrderByDescending(a => a.Capacity).FirstOrDefaultAsync();
				if (getAvailable == null)
				{
					response.Errors.Add(ResponseMessageConstants.NoRecordTableCapacity);
					return response;
				}

				_unitOfWork.ReservationRepository.Add(new Domain.Models.Entities.Reservation(request.CustomerId, getAvailable.Id, request.ReservationDate.Date, request.NumberOfGuests));
				await _unitOfWork.CompleteAsync();
			}
			catch (Exception ex)
			{
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
				await _unitOfWork.CompleteAsync(false);
				_logger.LogError(ex, ex.Message);
			}
			return response;

		}

		public Task<BaseResponseResult<List<ReservationResultDto>>> GetReservationList()
		{
			throw new NotImplementedException();
		}
	}
}
