using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Transaction
{
	public class GetOtpDtos
	{
		[MaxLength(16, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string SrcCardNumber { get; set; }
	}
}
