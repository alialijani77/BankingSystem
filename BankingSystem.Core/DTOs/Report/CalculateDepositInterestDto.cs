﻿namespace BankingSystem.Core.DTOs.Report
{
	public class CalculateDepositInterestDto
	{
		public int BranchId { get; set; }

		public string AccountNumber { get; set; }

		public long CustomerId { get; set; }

		public int DepositId { get; set; }

        public int Day { get; set; }

    }
}
