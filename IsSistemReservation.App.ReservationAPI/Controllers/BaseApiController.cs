using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{

	public class BaseApiController : ControllerBase
	{
		public readonly ILogger<BaseApiController> _logger;
		public BaseApiController(ILogger<BaseApiController> logger)
		{
			_logger = logger;
		}
	}
}
