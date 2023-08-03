using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepositController : ControllerBase
	{
		private readonly IDepositService _depositService;

		#region ctor
		public DepositController(IDepositService depositService)
		{
			_depositService = depositService;
		}
		#endregion

		[HttpPost("AddDeposit")]

		public async Task<IActionResult> AddDeposit(DepsoitDto depositDto)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.AddDeposit(depositDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}

		[HttpPut("UpdateDeposit")]
		public async Task<IActionResult> UpdateDeposit(UpdateDepsoitDto updateDepositDto)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.UpdateDeposit(updateDepositDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}


		[HttpDelete("DeleteDeposit")]
		public async Task<IActionResult> DeleteDeposit(int depositId)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.DeleteDeposit(depositId))
				{
					return Ok();
				}
			}
			return BadRequest();
		}
	}
}
