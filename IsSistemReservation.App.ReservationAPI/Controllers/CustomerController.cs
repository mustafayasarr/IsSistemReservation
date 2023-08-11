using IsSistemReservation.App.Core.Services.Customer;
using IsSistemReservation.App.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using IsSistemReservation.App.Domain.Models.Dtos.Customer;

namespace IsSistemReservation.App.ReservationAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CustomerController : BaseApiController
	{
		private ICustomerService _customerService;

		public CustomerController(ICustomerService customerService,ILogger<CustomerController> logger) : base(logger)
		{
			_customerService = customerService;
		}

		[HttpPost]
		public async Task<ActionResult> CreateCustomer(CustomerRequestDto request)
		{
			var response = await _customerService.CreateCustomer(request);

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpGet]
		public async Task<ActionResult<BaseResponseResult<CustomerResultDto>>> GetCustomerList()
		{
			var response = await _customerService.GetCustomerList();

			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
