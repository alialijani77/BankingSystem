using BankingSystem.Domain.Entities.Common;

namespace BankingSystem.Domain.Entities.Account.Customer
{
	public class OpenAccount : BaseEntity
	{
		#region Properties
		public long OpenAccountId { get; set; }

		public string AccountNumber { get; set; }

		public string CardNumber { get; set; }

		public int Cvv2 { get; set; }

		public string Expmonth { get; set; }

		public string ExpYear { get; set; }

		public int CardPassword { get; set; }

		public string Shaba { get; set; }

		public int DepositLotteryPoints { get; set; }

		public int DepositFacilityPoints { get; set; }

        public int WithdrawToAccountCount { get; set; }

        public int DepositToAccountCount { get; set; }

        public long TotaAccountBalance { get; set; }

        public string Otp { get; set; }
        #endregion

        #region Relations
		public int? BranchId { get; set; }

		public Branch.Branch Branch { get; set; }

		public int DepositId { get; set; }

		public Deposit.Deposit Deposit { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion
    }
}
