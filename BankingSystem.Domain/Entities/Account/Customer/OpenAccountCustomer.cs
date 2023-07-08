using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities.Account.Customer
{
	public class OpenAccountCustomer
	{
		#region Properties
		public int Id { get; set; }

		public long CustomerId { get; set; }

		public long OpenAccountId { get; set; }

        #endregion

        #region Relations
        public OpenAccount OpenAccount { get; set; }

        public Customer Customer { get; set; }

        #endregion
    }
}
