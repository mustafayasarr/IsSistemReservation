using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IsSistemReservation.App.Core.Services.TableCategory;
using IsSistemReservation.App.Core.Services.Table;
using IsSistemReservation.App.Domain.Models.Dtos.Table;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TableController : BaseApiController
	{
		private ITableService _tableService;

		
		public TableController(ILogger<TableController> logger, ITableService tableService) : base(logger)
		{
			_tableService = tableService;

		}

		[HttpGet]
		public async Task<ActionResult<BaseResponseResult<TableCategoryResultDto>>> GetAllTables()
		{
			var response = await _tableService.GetAllTables();

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
		[HttpGet]
		public async Task<ActionResult<BaseResponseResult<TableCategoryResultDto>>> GetAvailableTables()
		{
			var response = await _tableService.GetAvailableTables();

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponseResult>> CreateTable(TableRequestDto request)
		{
			var response = await _tableService.CreateTable(request);

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
