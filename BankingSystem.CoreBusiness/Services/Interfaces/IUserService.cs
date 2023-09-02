using BankingSystem.Core.DTOs.Account.User;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
    public interface IUserService
    {
		#region User
		Task<bool> CheckForLogin(LoginDto login);

		Task<UserDto> GetUserByNationalCode(string nationalCode);

		Task<bool> AddUser(UserDto userDto);

		//Task Save();
		#endregion

		#region Permission
		Task<bool> AddPermission(PermissionDto permissionDto);

		Task<bool> UpdatePermission(UpdatePermissionDto updatePermissionDto);

		Task<bool> DeletePermission(int permissionId);

		Task<bool> CheckUserPermission(long permissionId, string userId);
		#endregion
	}
}
