using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CustomerController : BaseApiController
	{
		public CustomerController(ILogger<CustomerController> logger) : base(logger)
		{
		}
	}
}
