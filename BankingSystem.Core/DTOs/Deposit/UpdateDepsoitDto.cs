﻿using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Deposit
{
	public class UpdateDepsoitDto
	{
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DepositId { get; set; }

		[MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string DepositName { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DepositInterestRate { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DepositDailyPointsRate { get; set; }

		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DepositFacilityPointsRate { get; set; }
	}
}
