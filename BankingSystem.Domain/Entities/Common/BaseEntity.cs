
namespace BankingSystem.Domain.Entities.Common
{
	public class BaseEntity
	{
        public long CreateUserId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool IsDelete { get; set; } = false;
    }
}
