namespace BankingSystem.Domain.Entities.Account.User
{
	public class UserKeyValue 
	{
		public int Key { get; set; }

		public string Value { get; set; }

        #region Relations

		public ICollection<User> Users { get; set; }

		#endregion
	}
}
