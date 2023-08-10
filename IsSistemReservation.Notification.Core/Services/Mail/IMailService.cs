using IsSistemReservation.Notification.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Core.Services.Mail
{
	public interface IMailService
	{
		Task SendMailAsync(MailMessageDto mailMessageDto);

		Task SendCustomerReservationRegistrationMailAsync(ReservationResultDto dto);
	}
}
