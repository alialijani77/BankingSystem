using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Account.User
{
	public class LoginDto
	{
		[Display(Name = "نام کاربری")]
		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string NationalCode { get; set; }

		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
