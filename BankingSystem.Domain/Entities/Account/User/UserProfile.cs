using BankingSystem.Domain.Entities.Common;

namespace BankingSystem.Domain.Entities.Account.User
{
	public class UserProfile : BaseEntity
	{
		#region Properties
		public long UserProfileId { get; set; }

        public string Value { get; set; }

        #endregion

        #region Relations
        public long UserId { get; set; }

        public User User { get; set; }

        public int Key { get; set; }

        public UserProfileKeyValue UserProfileKeyValue { get; set; }
        #endregion

		
    }
}
