using BankingSystem.Domain.Entities.Common;

namespace BankingSystem.Domain.Entities.Account.User
{
	public class User : BaseEntity
	{
		#region Properties
		public long UserId { get; set; }

		public string Name { get; set; }

		public string Family { get; set; }

		public string Password { get; set; }

		public string NationalCode { get; set; }

		public string Value { get; set; }

		#endregion

		#region Relations
		public int BranchId { get; set; } = 0;
		public Branch.Branch Branch { get; set; }

		public int PermissionId { get; set; }

		public Permission Permission { get; set; }

		public ICollection<UserProfile> UserProfiles { get; set; }

		public int Key { get; set; }

		public UserKeyValue UserKeyValue { get; set; }

		#endregion


	}
}
