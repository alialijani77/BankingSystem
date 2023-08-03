using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;
using BankingSystem.Core.Extensions;
using BankingSystem.Core.Statics;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class BranchService : IBranchService
	{
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Branch> _genericRepository;
		#region ctor
		public BranchService(BankingSystemDbContext context)
		{
			_context = context;
			_genericRepository = new GenericRepository<Branch>(_context);
		}
		#endregion
		#region GetBranch
		public async Task<BranchDto> GetBranchById(int branchId)
		{
			var branch = await _genericRepository.GetByID(branchId);
			if (branch != null)
			{
				return branch.GetBranchById();
			}
			return null;
		}
		#endregion

		#region AddBranch
		public async Task<bool> AddBranch(BranchDto branchDto)
		{
			var branch = branchDto.NewBranch();
			var IsExists = _genericRepository.Get(u => u.BranchCode == branch.BranchCode, null, "");

			if (branch != null && IsExists.Count() == 0)
			{
				await _genericRepository.Insert(branch);
				return true;
			}
			return false;
		}
		#endregion

		#region UpdateBranch
		public async Task<bool> UpdateBranch(UpdateBranchDto updateBranchDto)
		{
			var getBranchById = await _genericRepository.GetByID(updateBranchDto.BranchId);
			if (getBranchById != null)
			{
				var updateBranch = updateBranchDto.UpdateBranch(getBranchById);
				await _genericRepository.Update(updateBranch);
				return true;
			}
			return false;
		}
		#endregion

		#region DeleteBranch
		public async Task<bool> DeleteBranch(int branchId)
		{
			var getBranchById = await _genericRepository.GetByID(branchId);
			if (getBranchById != null)
			{
				var deleteBranch = getBranchById.DeleteBranch();
				await _genericRepository.Update(deleteBranch);
				return true;
			}
			return false;
		}
		#endregion
	}
}
