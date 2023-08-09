using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TableCategoryController : BaseApiController
	{
		public TableCategoryController(ILogger<TableCategoryController> logger) : base(logger)
		{
		}
	}
}
