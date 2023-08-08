using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Account.Customer
{
	public class OpenAccountDto
	{
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int BranchId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DepositId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public long CustomerId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public long TotaAccountBalance { get; set; }

		public int ExpDate { get; set; }
    }
}
