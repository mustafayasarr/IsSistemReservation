using IsSistemReservation.Notification.Domain.Models.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace IsSistemReservation.Notification.Core.Services.Mail
{
	public class MailService : IMailService
	{
		private readonly SmtpConfigDto _smtpConfigDto;
        public MailService(IOptions<SmtpConfigDto> options)
        {
			_smtpConfigDto = options.Value;

		}
		public async Task SendCustomerReservationRegistrationMailAsync(ReservationResultDto dto)
		{
			using var client = CreateSmtpClient();

			MailMessageDto mailMessageDto = new MailMessageDto
			{
				Body = $"Sayın {dto.Customer.Name}, rezervasyonunuz başarıyla alındı. Masa No: {dto.Table.Number}, Tarih: {dto.ReservationDate.Date}, Kişi Sayısı: {dto.NumberOfGuests}",
				To = dto.Customer.Email,
				Subject = "Rezervasyon Onayı",
				From = _smtpConfigDto.User
			};
			MailMessage mailMessage = mailMessageDto.GetMailMessage();
			mailMessage.IsBodyHtml = true;
			await client.SendMailAsync(mailMessage);
		}

		public async Task SendMailAsync(MailMessageDto mailMessageDto)
		{
			MailMessage mailMessage = mailMessageDto.GetMailMessage();
			mailMessage.From = new MailAddress(_smtpConfigDto.User);

			using var client = CreateSmtpClient();
			await client.SendMailAsync(mailMessage);
		}

		private SmtpClient CreateSmtpClient()
		{
			SmtpClient smtp = new SmtpClient(_smtpConfigDto.Host, _smtpConfigDto.Port);
			smtp.Credentials = new NetworkCredential(_smtpConfigDto.User, _smtpConfigDto.Password);
			smtp.EnableSsl = _smtpConfigDto.UseSsl;
			return smtp;
		}
	}
}
