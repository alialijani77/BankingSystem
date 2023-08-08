using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		#region ctor
		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}
		#endregion

		#region Customer
		[HttpPost("AddCustomer")]

		public async Task<IActionResult> AddCustomer(CustomerDto customerDto)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.AddCustomer(customerDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPut("UpdateCustomer")]
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.UpdateCustomer(updateCustomerDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}


		[HttpDelete("DeleteCustomer")]
		public async Task<IActionResult> DeleteCustomer(long customerId)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.DeleteCustomer(customerId))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
		#endregion


		[HttpPost("AddOpenAccount")]

		public async Task<IActionResult> AddOpenAccount(OpenAccountDto openAccountDto)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.AddOpenAccount(openAccountDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpDelete("DeleteOpenAccount")]
		public async Task<IActionResult> DeleteOpenAccount(int openAccountId)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.DeleteOpenAccount(openAccountId))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
	}
}
