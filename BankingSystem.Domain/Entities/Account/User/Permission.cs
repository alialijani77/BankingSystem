using BankingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankingSystem.Domain.Entities.Account.User
{
	public class Permission : BaseEntity
	{
		#region Properties
		[Key]		
		public int Id { get; set; }
		[Display(Name = "نام فارسی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string FaName { get; set; }

		[Display(Name = "نام انگلیسی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string EnName { get; set; }

		public long Count { get; set; } = 0;
		#endregion

		#region Relations
		public ICollection<User> Users { get; set; }
        #endregion
    }
}
