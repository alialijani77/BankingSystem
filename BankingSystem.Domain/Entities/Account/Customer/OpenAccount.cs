using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities.Account.Customer
{
	public class OpenAccount : BaseEntity
	{
		#region Properties
		public long OpenAccountId { get; set; }

		public string AccountNumber { get; set; }

		public string CardNumber { get; set; }

		public int Cvv2 { get; set; }

		public string ExpDate { get; set; }

		public int CardPassword { get; set; }

		public string Shaba { get; set; }

		public int DepositLotteryPoints { get; set; }

		public int DepositFacilityPoints { get; set; }
        #endregion

        #region Relations
        public ICollection<OpenAccountCustomer> OpenAccountCustomers { get; set; }

		public int? BranchId { get; set; }

		public Branch.Branch Branch { get; set; }

		public int DepositId { get; set; }

		public Deposit.Deposit Deposit { get; set; }
        #endregion
    }
}
