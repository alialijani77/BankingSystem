using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities.Deposit
{
	public class Deposit : BaseEntity
	{
		#region Properties
		public int DepositId { get; set; }

        public string DepositName { get; set; }

        public int DepositInterestRate { get; set; }

        public int DepositDailyPointsRate { get; set; }

        public int DepositFacilityPointsRate { get; set; }

        #endregion

        #region Relations

        public ICollection<OpenAccount> OpenAccounts { get; set; }

        #endregion
    }
}
