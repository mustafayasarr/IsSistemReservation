using IsSistemReservation.Notification.Core.Managers.Hangfire;
using IsSistemReservation.Notification.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.Notification.NotificationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MailController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<BaseResponseResult>> SendCustomerReservationMail(ReservationResultDto request)
		{
			var response = FireAndForgetJobs.SendCustomerMailJob(request);

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
