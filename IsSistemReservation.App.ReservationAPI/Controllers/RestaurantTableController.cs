using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RestaurantTableController : BaseApiController
	{
		public RestaurantTableController(ILogger<RestaurantTableController> logger) : base(logger)
		{
		}
	}
}
