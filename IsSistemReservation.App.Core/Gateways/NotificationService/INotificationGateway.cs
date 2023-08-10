using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Core.Gateways.NotificationService
{
	public interface INotificationGateway
	{
		Task<BaseResponseResult> SendCustomerReservationMail(ReservationResultDto request);
	}
}
