using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.DTOs.Transaction
{
	[Serializable]
	public class TransactionResultDtos
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }
	}
}
