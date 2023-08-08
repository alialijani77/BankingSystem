using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;
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

		[HttpGet("GetDeposit")]
		public async Task<IActionResult> GetDeposit()
		{
			if (ModelState.IsValid)
			{
				var branch = await _depositService.GetDeposit();
				if (branch != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<BranchDto>.CreateSuccess(branch));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("GetDepositById")]
		public async Task<IActionResult> GetDepositById(int depositId)
		{
			if (ModelState.IsValid)
			{
				var branch = await _depositService.GetDepositById(depositId);
				if (branch != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<BranchDto>.CreateSuccess(branch));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPost("AddDeposit")]

		public async Task<IActionResult> AddDeposit(AddDepsoitDto depositDto)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.AddDeposit(depositDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPut("UpdateDeposit")]
		public async Task<IActionResult> UpdateDeposit(UpdateDepsoitDto updateDepositDto)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.UpdateDeposit(updateDepositDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}


		[HttpDelete("DeleteDeposit")]
		public async Task<IActionResult> DeleteDeposit(int depositId)
		{
			if (ModelState.IsValid)
			{
				if (await _depositService.DeleteDeposit(depositId))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
	}
}
