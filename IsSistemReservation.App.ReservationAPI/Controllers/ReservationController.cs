using IsSistemReservation.App.Core.Services.Table;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using IsSistemReservation.App.Core.Services.Reservation;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ReservationController : BaseApiController
	{
		private IReservationService _reservationService;

		public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService) : base(logger)
		{
			_reservationService	= reservationService;
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponseResult>> CreateReservation(ReservationRequestDto request)
		{
			var response = await _reservationService.CreateReservation(request);

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpGet]
		public async Task<ActionResult<BaseResponseResult<List<ReservationResultDto>>>> GetReservationList()
		{
			var response = await _reservationService.GetReservationList();

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}

