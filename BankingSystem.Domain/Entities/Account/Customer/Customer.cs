using BankingSystem.Domain.Entities.Common;

namespace BankingSystem.Domain.Entities.Account.Customer
{
    public class Customer : BaseEntity
	{
		#region Properties
		public long CustomerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string NationalCode { get; set; }

		public string SignatureImage { get; set; }

		public string PhoneNumber { get; set; }

		public long TotalAmount { get; set; }

		public int? StateId { get; set; }

        public int? CityId { get; set; }
        #endregion

        #region Relations
        public State? State { get; set; }

		public State? City { get; set; }

        public ICollection<OpenAccount> OpenAccounts { get; set; }
        #endregion
    }
}
