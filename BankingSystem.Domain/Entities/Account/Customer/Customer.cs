using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		#endregion

		#region Relations
		public ICollection<OpenAccountCustomer> OpenAccountCustomers { get; set; }

		#endregion
	}
}
