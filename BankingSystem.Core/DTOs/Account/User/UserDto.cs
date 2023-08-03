using BankingSystem.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Account.User
{
	public class UserDto
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string Name { get; set; }
		
		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string Family { get; set; }

		//public int Key { get; set; }
		//public string Value { get; set; }

		public List<UserKeyValueDto> KeyValues { get; set; }
		//[Display(Name = "شماره موبایل")]
		//[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		//[MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		//[RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل وارد شده معتبر نمی باشد .")]
		//public string PhoneNumber { get; set; }

		[Display(Name = "رمز عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string Password { get; set; }

		[Display(Name = "کد ملی")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string NationalCode { get; set; }

		//[Display(Name = "آدرس")]
		//[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		//public string Address { get; set; }

		//[Display(Name = "تصویر پروفایل")]
		//public string Avatar { get; set; }

		public int BranchId { get; set; } = 0;

		public int PermissionId { get; set; }

        public List<UserProfileDto> UserProfiles { get; set; }


        public static async Task<bool> ValidationUser(UserDto userDto)
		{
			if (userDto.NationalCode.ValidateNationalode())
			{
				return false;
			}
			return true;
		}

		public async Task<Domain.Entities.Account.User.User> NewUser(UserDto userDto,int key,string value)
		{
			if (!await ValidationUser(userDto))
			{
				return null;
			}
			var user = userDto.NewUser(key, value);
			return user;
		}
	}
}