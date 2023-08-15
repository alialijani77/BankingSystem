using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;
using BankingSystem.Core.DTOs.Report;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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
	}
}
