using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IBranchService
	{
		Task<BranchDto> GetBranchById(int branchId);

		Task<bool> AddBranch(BranchDto branchDto);

		Task<bool> UpdateBranch(UpdateBranchDto updateBranchDto);

		Task<bool> DeleteBranch(int branchId);

	}
}
