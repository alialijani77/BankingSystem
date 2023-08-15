using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.DTOs.Report
{
	public class CalculateDepositInterestResultDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public long TotalAmount { get; set; }

		public string DepositName { get; set; }

		public long DepositInterest { get; set; }


	}
}
