using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ReservationController : BaseApiController
	{
		public ReservationController(ILogger<ReservationController> logger) : base(logger)
		{
		}
	}
}

