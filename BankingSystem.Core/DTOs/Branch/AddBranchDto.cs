using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Branch
{
	public class AddBranchDto
	{
		[MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string BranchName { get; set; }

		[MaxLength(4, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string BranchCode { get; set; }

		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Address { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? StateId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? CityId { get; set; }
	}
}
