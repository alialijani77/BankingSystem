using BankingSystem.Core.DTOs.Account.User;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.User;
using BankingSystem.Domain.Interfaces.UnitOfWork;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
    public class UserService : IUserService
    {
        //private readonly IUnitOfWork _unitOfWork;
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<User> _genericRepositoryForUser;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<UserProfile> _genericRepositoryForUserProfile;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Permission> _genericRepositoryForPermission;




		#region ctor
		public UserService(BankingSystemDbContext context, IUnitOfWork unitOfWork)
		{
			//_unitOfWork = unitOfWork;
			_context = context;
			_genericRepositoryForUser = new GenericRepository<User>(_context);
			_genericRepositoryForUserProfile = new GenericRepository<UserProfile>(_context);
			_genericRepositoryForPermission = new GenericRepository<Permission>(_context);
		}
		#endregion

		public async Task<bool> AddUser(UserDto userDto)
        {
            foreach (var item in userDto.KeyValues)
            {
				var user = await userDto.NewUser(userDto, item.Key, item.Value);
				if(user == null)
				{
					return false;
				}
				else
				{
					//await _unitOfWork.GetRepository<User>().Insert(user);

					await _genericRepositoryForUser.Insert(user);
					foreach (var userProfile in userDto.UserProfiles)
					{
						var userPr = UserExtensions.NewUserProfile(user.UserId, userProfile.Key, userProfile.Value);
						await _genericRepositoryForUserProfile.Insert(userPr);
					}
				}
			}
			await _genericRepositoryForUser.CommitAsync();
			return true;
        }

		//public async Task Save()
		//{
		//	//await _unitOfWork.CommitAsync();
		//	await _genericRepositoryForUser.CommitAsync();
		//}

		#region Permission

		#region AddPermission
		public async Task<bool> AddPermission(PermissionDto permissionDto)
		{
			var permission = permissionDto.NewPermission();
			if (permission != null)
			{
				await _genericRepositoryForPermission.Insert(permission);
				return true;
			}
			return false;
		}
		#endregion

		#region UpdatePermission
		public async Task<bool> UpdatePermission(UpdatePermissionDto updatePermissionDto)
		{
			var getPermissionById = await _genericRepositoryForPermission.GetByID(updatePermissionDto.PermissionId);
			if (getPermissionById != null)
			{
				var updatePermission = updatePermissionDto.UpdatePermission(getPermissionById);
				await _genericRepositoryForPermission.Update(updatePermission);
				return true;
			}
			return false;
		}
		#endregion

		#region DeletePermission
		public async Task<bool> DeletePermission(int permissionId)
		{
			var getPermissionById = await _genericRepositoryForPermission.GetByID(permissionId);
			if (getPermissionById != null)
			{
				var deletePermission = getPermissionById.DeletePermission();
				await _genericRepositoryForPermission.Update(deletePermission);
				return true;
			}
			return false;
		}
		#endregion

		#endregion
	}
}
