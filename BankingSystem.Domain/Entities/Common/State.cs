using BankingSystem.Domain.Entities.Account.Customer;

namespace BankingSystem.Domain.Entities.Common
{
    public class State : BaseEntity
    {
        #region Properties
        public int StateId { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }
        #endregion

        #region Relations
        public State? Parent { get; set; }

        public ICollection<Customer> CustomerStates { get; set; }

        public ICollection<Customer> CustomerCities { get; set; }

		public ICollection<Branch.Branch> BranchStates { get; set; }

		public ICollection<Branch.Branch> BranchCities { get; set; }

		#endregion

	}
}
