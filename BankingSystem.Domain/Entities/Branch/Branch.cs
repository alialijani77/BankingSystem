using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankingSystem.Domain.Entities.Branch
{
	public class Branch : BaseEntity
	{
		#region Properties
        public int BranchId { get; set; }

		public string BranchName { get; set; }

		public string BranchCode { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

        public int CustomerCount { get; set; }

        public long TotalAmount { get; set; }

		#endregion

		#region Relations
		public ICollection<User> Users { get; set; }

		public ICollection<OpenAccount> OpenAccounts { get; set; }

		#endregion
	}
}
