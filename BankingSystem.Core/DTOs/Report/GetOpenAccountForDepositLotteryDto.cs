﻿namespace BankingSystem.Core.DTOs.Report
{
	public class GetOpenAccountForDepositLotteryDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string NationalCode { get; set; }

		public string AccountNumber { get; set; }

		public string CardNumber { get; set; }

		public string Shaba { get; set; }

		public int DepositId { get; set; }
	}
}
