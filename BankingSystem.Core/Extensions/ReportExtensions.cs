using BankingSystem.Core.DTOs.Report;
using BankingSystem.Domain.Entities.Account.Customer;

namespace BankingSystem.Core.Extensions
{
	public static class ReportExtensions
	{
		public static CalculateDepositInterestResultDto GetCalculateDepositInterestResult(this OpenAccount openAccount, int day)
		{
			var calculateDepositInterestResultDto = new CalculateDepositInterestResultDto();
			calculateDepositInterestResultDto.FirstName = openAccount.Customer.FirstName;
			calculateDepositInterestResultDto.LastName = openAccount.Customer.LastName;
			calculateDepositInterestResultDto.DepositName = openAccount.Deposit.DepositName;
			calculateDepositInterestResultDto.TotalAmount = openAccount.Customer.TotalAmount;
			calculateDepositInterestResultDto.DepositInterest = (openAccount.Deposit.DepositInterestRate * openAccount.Customer.TotalAmount * day) / 36500;
			return calculateDepositInterestResultDto;
		}

		public static List<GetOpenAccountForDepositLotteryDto> GetOpenAccountForDepositLotteryResult(this List<OpenAccount> openAccounts)
		{
			var OpenAccountForDepositLotterysDto = new List<GetOpenAccountForDepositLotteryDto>();
			foreach (var item in openAccounts)
			{
				var OpenAccountForDepositLotteryDto = new GetOpenAccountForDepositLotteryDto();
				OpenAccountForDepositLotteryDto.FirstName = item.Customer.FirstName;
				OpenAccountForDepositLotteryDto.LastName = item.Customer.LastName;
				OpenAccountForDepositLotteryDto.AccountNumber = item.AccountNumber;
				OpenAccountForDepositLotteryDto.CardNumber = item.CardNumber;
				OpenAccountForDepositLotteryDto.Shaba = item.Shaba;
				OpenAccountForDepositLotteryDto.DepositId = item.Deposit.DepositId;
				OpenAccountForDepositLotterysDto.Add(OpenAccountForDepositLotteryDto);
			}
			return OpenAccountForDepositLotterysDto;
		}

		public async static Task<List<OpenAccount>> CalculateOpenAccountDepositLottery(this List<OpenAccount> openAccounts)
		{
			//var updateOpenAccounts = new List<OpenAccount>();
			var validations = openAccounts.Select(openAccount => updateOpenAccountss(openAccount));
			var result = (await Task.WhenAll(validations)).ToList();
			return result;
			//foreach (var item in openAccounts)//pararell foreache list taks
			//{
			//	int diff = DateTime.Now.Subtract(item.CreateDate).Days;
			//	item.DepositLotteryPoints = diff * item.Deposit.DepositInterestRate;
			//	updateOpenAccounts.Add(item);
			//}
			//return updateOpenAccounts;
		}
		public async static Task<OpenAccount> updateOpenAccountss(OpenAccount openAccount)
		{
			//var updateOpenAccounts = new List<OpenAccount>();
			int diff = DateTime.Now.Subtract(openAccount.CreateDate).Days;
			openAccount.DepositLotteryPoints = diff * openAccount.Deposit.DepositInterestRate;
			//updateOpenAccounts.Add(openAccount);
			return openAccount;
		}

		public async static Task<List<CalculateOpenAccountDepositLotteryDto>> CalculateOpenAccountDepositLotteryResult(this List<OpenAccount> openAccounts)
		{
			var calculateOpenAccountDepositLotterys = new List<CalculateOpenAccountDepositLotteryDto>();
			foreach (var item in openAccounts)
			{
				var CalculateOpenAccountDepositLottery = new CalculateOpenAccountDepositLotteryDto();
				CalculateOpenAccountDepositLottery.FirstName = item.Customer.FirstName;
				CalculateOpenAccountDepositLottery.LastName = item.Customer.LastName;
				CalculateOpenAccountDepositLottery.AccountNumber = item.AccountNumber;
				CalculateOpenAccountDepositLottery.CardNumber = item.CardNumber;
				CalculateOpenAccountDepositLottery.DepositName = item.Deposit.DepositName;
				CalculateOpenAccountDepositLottery.DepositLotteryPoints = item.DepositLotteryPoints;
				calculateOpenAccountDepositLotterys.Add(CalculateOpenAccountDepositLottery);
			}
			return calculateOpenAccountDepositLotterys;
		}

		public async static Task<List<LotteryResultDto>> GetLotteryResult(this List<OpenAccount> openAccounts, int count)
		{
			var GetLotteryResultDtos = new List<LotteryResultDto>();
			Random r = new Random();
			List<long> randoms = openAccounts.OrderBy(o => r.Next()).Take(count).Select(o => o.OpenAccountId).ToList();
			foreach (var item2 in randoms)
			{
				var result = openAccounts.Where(o => o.OpenAccountId == item2);
				foreach (var item in result)
				{
					var GetLotteryResultDto = new LotteryResultDto();
					GetLotteryResultDto.FirstName = item.Customer.FirstName;
					GetLotteryResultDto.LastName = item.Customer.LastName;
					GetLotteryResultDto.AccountNumber = item.AccountNumber;
					GetLotteryResultDto.CardNumber = item.CardNumber;
					GetLotteryResultDto.Shaba = item.Shaba;
					GetLotteryResultDto.DepositLotteryPoints = item.DepositLotteryPoints;
					GetLotteryResultDtos.Add(GetLotteryResultDto);
				}
			}
			return GetLotteryResultDtos;
		}
	}
}
