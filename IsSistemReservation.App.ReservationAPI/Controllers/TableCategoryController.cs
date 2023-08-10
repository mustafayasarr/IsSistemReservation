using IsSistemReservation.App.Core.Services.TableCategory;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class TableCategoryController : BaseApiController
	{
		private ITableCategoryService _tableCategoryService;

		public TableCategoryController(ILogger<TableCategoryController> logger,ITableCategoryService tablecategoryService) : base(logger)
		{
			_tableCategoryService = tablecategoryService;
		}


		[HttpGet]
		public async Task<ActionResult<BaseResponseResult<TableCategoryResultDto>>> GetTableCategories()
		{
			var response = await _tableCategoryService.GetTableCategories();

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponseResult>> CreateTableCategories(TableCategoryRequestDto dto)
		{
			var response = await _tableCategoryService.CreateTableCategories(dto);

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

	}
}
