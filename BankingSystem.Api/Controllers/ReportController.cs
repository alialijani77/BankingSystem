using BankingSystem.Core.DTOs.Report;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ReportController : ControllerBase
	{
		private readonly IReportService _reportService;

		public ReportController(IReportService reportService)
		{
			_reportService = reportService;
		}

		[HttpGet("GetCalculateDepositInterest")]
		public async Task<IActionResult> GetCalculateDepositInterest(CalculateDepositInterestDto calculateDepositInterestDto)
		{
			if (ModelState.IsValid)
			{
				var calculateDepositResult = await _reportService.GetCalculateDepositInterest(calculateDepositInterestDto);
				if (calculateDepositResult != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return Ok(calculateDepositResult);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("GetOpenAccountForDepositLottery")]
		public async Task<IActionResult> GetOpenAccountForDepositLottery(long minMoneyForDepositLottery, long customerId)
		{
			if (ModelState.IsValid)
			{
				var OpenAccountForDepositLottery = await _reportService.GetOpenAccountForDepositLottery(minMoneyForDepositLottery, customerId);
				if (OpenAccountForDepositLottery != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return Ok(OpenAccountForDepositLottery);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("CalculateOpenAccountDepositLottery")]
		public async Task<IActionResult> CalculateOpenAccountDepositLottery(long customerId)
		{
			if (ModelState.IsValid)
			{
				var CalculateOpenAccountDepositLottery = await _reportService.CalculateOpenAccountDepositLottery(customerId);
				if (CalculateOpenAccountDepositLottery != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return Ok(CalculateOpenAccountDepositLottery);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("Lottery")]
		public async Task<IActionResult> Lottery(LotteryDto lotteryDto)
		{
			if (ModelState.IsValid)
			{
				var WinOpenAccountLottery = await _reportService.Lottery(lotteryDto);
				if (WinOpenAccountLottery != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return Ok(WinOpenAccountLottery);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("Facility")]
		public async Task<IActionResult> Facility(FacilityResultDto facilityResultDto)
		{
			if (ModelState.IsValid)
			{
				var facility = await _reportService.Facility(facilityResultDto);
				if (facility != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return Ok(facility);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
	}
}
