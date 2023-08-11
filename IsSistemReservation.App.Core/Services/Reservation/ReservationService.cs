using IsSistemReservation.App.Core.Gateways.NotificationService;
using IsSistemReservation.App.Core.Services.Table;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Customer;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using IsSistemReservation.App.Domain.Models.Dtos.Table;
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
		private IUnitOfWork @object;
		private object value;
		private readonly ILogger<ReservationService> _logger;
		private readonly INotificationGateway _notificationGateway;

		public ReservationService(IUnitOfWork unitOfWork, INotificationGateway notificationGateway, ILogger<ReservationService> logger)
		{
			_notificationGateway = notificationGateway;
			_unitOfWork = unitOfWork;
			_logger = logger;
		}



		public async Task<BaseResponseResult> CreateReservation(ReservationRequestDto request)
		{
			var response = new BaseResponseResult();

			try
			{
				var getCustomer = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(a=>a.Id==request.CustomerId);
				if (getCustomer == null)
				{
					response.Errors.Add(new Error(ResponseMessageConstants.NoRecordCustomerCode, ResponseMessageConstants.NoRecordCustomer));
					return response;
				}

				var getReservation = await _unitOfWork.ReservationRepository.FirstOrDefaultAsync(a => a.CustomerId == request.CustomerId && a.ReservationDate.Day == request.ReservationDate.Day && a.IsActive);
				if (getReservation != null)
				{
					response.Errors.Add(new Error(ResponseMessageConstants.AllreadyRecordDataCode, ResponseMessageConstants.AllreadyRecordData));
					return response;
				}

				var getAvailable = await _unitOfWork.TableRepository.Table.Include(a => a.Reservations).Where(a => !a.Reservations.Any(c => c.ReservationDate.Date == request.ReservationDate.Date && !c.IsDeleted && c.IsActive) && a.Capacity >= request.NumberOfGuests && a.IsActive && !a.IsDeleted).OrderBy(a => a.Capacity).FirstOrDefaultAsync();
				if (getAvailable == null)
				{
					response.Errors.Add(new Error(ResponseMessageConstants.NoRecordTableCapacityCode, ResponseMessageConstants.NoRecordTableCapacity));
					return response;
				}
				var entity = new Domain.Models.Entities.Reservation(request.CustomerId, getAvailable.Id, request.ReservationDate.Date, request.NumberOfGuests);
				_unitOfWork.ReservationRepository.Add(entity);
				await _unitOfWork.CompleteAsync();

				var responseGateway = await _notificationGateway.SendCustomerReservationMail(new ReservationResultDto(entity.Id, entity.ReservationDate, entity.NumberOfGuests, new CustomerResultDto(getCustomer.Id, getCustomer.Name, getCustomer.LastName, getCustomer.TelNo, getCustomer.Email), new TableResultDto(getAvailable.TableName, getAvailable.Number, getAvailable.Capacity, null, entity.CreatedDate)));

				if (responseGateway.HasError)
				{
					_logger.LogError("E-posta servisinden hata döndü", responseGateway.Errors.ToString());
				}
			}
			catch (Exception ex)
			{
				response.Errors.Add(new Error(ResponseMessageConstants.AnErrorOccurredCode, ResponseMessageConstants.AnErrorOccurred));
				await _unitOfWork.CompleteAsync(false);
				_logger.LogError(ex, ex.Message);
			}
			return response;

		}

		public async Task<BaseResponseResult<List<ReservationResultDto>>> GetReservationList()
		{
			var response = new BaseResponseResult<List<ReservationResultDto>>();
			try
			{
				response.Result = await _unitOfWork.ReservationRepository.Table.Include(a => a.Table).Include(a => a.Customer).Where(a => a.IsActive && !a.IsDeleted && a.ReservationDate.Date <= DateTime.Now.Date).Select(a => new ReservationResultDto(a.Id, a.ReservationDate, a.NumberOfGuests, new CustomerResultDto(a.Customer.Id, a.Customer.Name, a.Customer.LastName, a.Customer.TelNo, a.Customer.Email), new TableResultDto(a.Table.TableName, a.Table.Number, a.Table.Capacity, null, a.Table.CreatedDate))).ToListAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(new Error(ResponseMessageConstants.AnErrorOccurredCode, ResponseMessageConstants.AnErrorOccurred));
			}
			return response;

		}
	}
}