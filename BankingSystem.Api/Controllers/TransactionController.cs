using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.CoreBusiness.Services.Implementions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
				var TransactionResultDto = await _transactionService.Transfer(transactionDtos);
				return Ok(TransactionResultDto);
				
			}
			return BadRequest();
		}
	}
}
