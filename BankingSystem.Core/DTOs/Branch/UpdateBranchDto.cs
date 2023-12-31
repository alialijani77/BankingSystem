﻿using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Branch
{
	public class UpdateBranchDto
	{
		public int BranchId { get; set; }

		[MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string BranchName { get; set; }

		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string BranchCode { get; set; }

		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Address { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? StateId { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int? CityId { get; set; }
	}
}
