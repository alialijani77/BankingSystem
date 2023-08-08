using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Account.User
{
	public class PermissionDto
	{
		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string FaName { get; set; }

		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string EnName { get; set; }

	}
}
