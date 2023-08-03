using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Entities.Common;

namespace BankingSystem.Domain.Entities.Branch
{
	public class Branch : BaseEntity
	{
		#region Properties
        public int BranchId { get; set; }

		public string BranchName { get; set; }

		public string BranchCode { get; set; }

		public int? StateId { get; set; }

		public int? CityId { get; set; }

		public string Address { get; set; }

		public int CustomerCount { get; set; }

        public long TotalAmount { get; set; }


		#endregion

		#region Relations
		public ICollection<User> Users { get; set; }

		public ICollection<OpenAccount> OpenAccounts { get; set; }

		public State? State { get; set; }

		public State? City { get; set; }

		#endregion
	}
}
