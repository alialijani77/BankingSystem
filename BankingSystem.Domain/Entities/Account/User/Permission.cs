using BankingSystem.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;


namespace BankingSystem.Domain.Entities.Account.User
{
	public class Permission : BaseEntity
	{
        #region Properties
        public int PermissionId { get; set; }

        public string FaName { get; set; }

		public string EnName { get; set; }

		public long Count { get; set; } = 0;
		#endregion

		#region Relations
		public ICollection<User> Users { get; set; }
        #endregion
    }
}
