namespace BankingSystem.Domain.Entities.Account.User
{
	public class UserProfileKeyValue
	{
		public int Key { get; set; }

		public string Value { get; set; }

		#region Relations
		public ICollection<UserProfile> UserProfiles { get; set; }

		#endregion
	}
}
