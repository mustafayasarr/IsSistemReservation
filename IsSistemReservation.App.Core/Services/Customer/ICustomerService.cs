using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using IsSistemReservation.App.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsSistemReservation.App.Domain.Models.Dtos.Customer;

namespace IsSistemReservation.App.Core.Services.Customer
{
	public interface ICustomerService
	{
		Task<BaseResponseResult> CreateCustomer(CustomerRequestDto request);
	}
}
