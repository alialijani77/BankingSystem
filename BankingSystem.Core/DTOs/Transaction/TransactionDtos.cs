using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Transaction
{
	public class TransactionDtos
	{
		[MaxLength(16, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string SrcCardNumber { get; set; }

		[MaxLength(3, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int Cvv2 { get; set; }

		[MaxLength(2, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Expmonth { get; set; }

		[MaxLength(2, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string ExpYear { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CardPassword { get; set; }

		[MaxLength(4, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Otp { get; set; }

		[MaxLength(16, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string DstCardNumber { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public long Amount { get; set; }


	}
}
