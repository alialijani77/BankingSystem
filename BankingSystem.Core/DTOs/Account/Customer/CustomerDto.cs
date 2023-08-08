using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Account.Customer
{
	public class CustomerDto
	{
		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string FirstName { get; set; }

		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string LastName { get; set; }

		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string NationalCode { get; set; }

		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string SignatureImage { get; set; }

		[MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل وارد شده معتبر نمی باشد .")]

		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? StateId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? CityId { get; set; }
	}
}
