using Hangfire;
using IsSistemReservation.Notification.Domain.Models.Constants;
using IsSistemReservation.Notification.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Core.Managers.Hangfire
{
	public static class FireAndForgetJobs
	{
		public static BaseResponseResult SendMailJob(MailMessageDto mailMessageDto)
		{
			var response=new BaseResponseResult();
			try
			{
				BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
				(
				 job => job.SendMail(mailMessageDto)
				 );

			}
			catch (Exception ex)
			{
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);

			}
			return response;
		}
		public static BaseResponseResult SendCustomerMailJob(ReservationResultDto dto)
		{
			var response = new BaseResponseResult();
			try
			{
				BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
				(
				 job => job.SendCustomerMail(dto)
				 );

			}
			catch (Exception ex)
			{
				response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);

			}
			return response;
		}
	}
}
