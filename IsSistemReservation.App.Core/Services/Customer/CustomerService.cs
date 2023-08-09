using IsSistemReservation.App.Core.Services.Reservation;
using IsSistemReservation.App.Domain.Models.Constants;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Customer;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Services.Customer
{
	public class CustomerService : ICustomerService
	{
		private IUnitOfWork _unitOfWork;
		private readonly ILogger<CustomerService> _logger;
		public CustomerService(IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<BaseResponseResult> CreateCustomer(CustomerRequestDto request)
		{
			var response = new BaseResponseResult();

			try
			{
				if (_unitOfWork.CustomerRepository.Table.Any(a => a.Email == request.Email))
				{
					response.Errors.Add(ResponseMessageConstants.AllreadyRecordData);
					return response;
				}
				_unitOfWork.CustomerRepository.Add(new Domain.Models.Entities.Customer(request.Name,request.LastName,request.TelNo,request.Email));
				await _unitOfWork.CompleteAsync();
				
			}
			catch (Exception ex)
			{
				await _unitOfWork.CompleteAsync(false);
				_logger.LogError(ex, ex.Message);
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
			}
			return response;
		}
	}
}
