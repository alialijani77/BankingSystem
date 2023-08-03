using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.CoreBusiness.Services.Implementions;
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
					return Ok();
				}
			}
			return BadRequest();
		}

		[HttpPut("UpdateCustomer")]
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.UpdateCustomer(updateCustomerDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}


		[HttpDelete("DeleteCustomer")]
		public async Task<IActionResult> DeleteCustomer(int customerId)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.DeleteCustomer(customerId))
				{
					return Ok();
				}
			}
			return BadRequest();
		}
		#endregion


		[HttpPost("AddOpenAccount")]

		public async Task<IActionResult> AddOpenAccount(OpenAccountDto openAccountDto)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.AddOpenAccount(openAccountDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}

		[HttpDelete("DeleteOpenAccount")]
		public async Task<IActionResult> DeleteOpenAccount(int openAccountId)
		{
			if (ModelState.IsValid)
			{
				if (await _customerService.DeleteOpenAccount(openAccountId))
				{
					return Ok();
				}
			}
			return BadRequest();
		}
	}
}
