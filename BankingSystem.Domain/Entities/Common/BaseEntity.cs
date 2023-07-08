using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities.Common
{
	public class BaseEntity
	{
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
	}
}
