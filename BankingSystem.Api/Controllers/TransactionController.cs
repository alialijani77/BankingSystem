using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly ITransactionService _transactionService;

		public TransactionController(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		[HttpPost("AddTransaction")]

		public async Task<IActionResult> AddTransaction(TransactionDtos transactionDtos)
		{
			if (ModelState.IsValid)
			{
				var transactionResultDto = await _transactionService.Transfer(transactionDtos);
				Response.StatusCode = StatusCodes.Status200OK;
				return new JsonResult(ApiResultDto<bool>.CreateSuccess(transactionResultDto.IsSuccess, transactionResultDto.IsSuccess, transactionResultDto.Message));
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("GetOtp")]

		public async Task<IActionResult> GetOtp(GetOtpDtos getOtp)
		{
			if (ModelState.IsValid)
			{
				var otp = await _transactionService.GetOtp(getOtp);
				if (otp != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<string>.CreateSuccess(otp));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());

		}

		[HttpGet("GetShaba")]

		public async Task<IActionResult> GetShaba(GetShabaDtos getShaba)
		{
			if (ModelState.IsValid)
			{
				var shaba = await _transactionService.GetShaba(getShaba);
				if (shaba != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<string>.CreateSuccess(shaba));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
	}
}
