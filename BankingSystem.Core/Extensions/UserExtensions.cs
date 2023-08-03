using BankingSystem.Core.DTOs.Account.User;
using BankingSystem.Domain.Entities.Account.User;

namespace BankingSystem.Core.Extensions
{
	public static class UserExtensions
	{
		#region User
		public static User NewUser(this UserDto userDto, int key, string value)
		{
			var user = new Domain.Entities.Account.User.User();
			user.Name = userDto.Name;
			user.Family = userDto.Family;
			user.Value = value;
			user.Key = key;
			//user.PhoneNumber = userDto.PhoneNumber;
			user.Password = userDto.Password;
			user.NationalCode = userDto.NationalCode;
			//user.Address = userDto.Address;
			//user.Avatar = userDto.Avatar;
			user.BranchId = userDto.BranchId;
			user.PermissionId = userDto.PermissionId;
			return user;
		}
		#endregion

		#region UserProfile

		public static UserProfile NewUserProfile(long userId, int key, string value)
		{
			var userProfile = new Domain.Entities.Account.User.UserProfile();
			userProfile.UserId = userId;
			userProfile.Key = key;
			userProfile.Value = value;
			return userProfile;

		}
		#endregion

		#region Permission
		public static Permission NewPermission(this PermissionDto permissionDto)
		{
			var permission = new Permission();
			permission.FaName = permissionDto.FaName;
			permission.EnName = permissionDto.EnName;
			return permission;
		}

		public static Permission UpdatePermission(this UpdatePermissionDto updatePermissionDto, Permission permission)
		{
			permission.FaName = updatePermissionDto.FaName;
			permission.EnName = updatePermissionDto.EnName;
			permission.CreateDate = DateTime.Now;
			return permission;
		}

		public static Permission DeletePermission(this Permission permission)
		{
			permission.IsDelete = true;
			permission.CreateDate = DateTime.Now;
			return permission;
		}
		#endregion
	}
}
