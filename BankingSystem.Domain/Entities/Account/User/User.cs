using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities.Account.User
{
	public class User : BaseEntity
	{
		#region Properties
		public long UserId { get; set; }

		public string Name { get; set; }

		public string Family { get; set; }

		public string PhoneNumber { get; set; }

		public string Password { get; set; }

		public string NationalCode { get; set; }

		public string Address { get; set; }

		public string Avatar { get; set; }

		#endregion

		#region Relations
		public int? BranchId { get; set; }

		public Branch.Branch Branch { get; set; }

		public int PermissionId { get; set; }

		public Permission Permission { get; set; }

		#endregion


	}
}
