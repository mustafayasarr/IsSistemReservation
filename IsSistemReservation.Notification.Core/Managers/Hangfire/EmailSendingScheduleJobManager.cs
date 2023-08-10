using IsSistemReservation.Notification.Core.Services.Mail;
using IsSistemReservation.Notification.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Core.Managers.Hangfire
{
	public class EmailSendingScheduleJobManager
	{
		private readonly IMailService _mailService;
		public EmailSendingScheduleJobManager(IMailService mailService)
		{
			_mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
		}

		public async Task SendMail(MailMessageDto mailMessageDto)
		{
			await _mailService.SendMailAsync(mailMessageDto);
		}
		public async Task SendCustomerMail(ReservationResultDto dto)
		{
			await _mailService.SendCustomerReservationRegistrationMailAsync(dto);
		}
	}
}
