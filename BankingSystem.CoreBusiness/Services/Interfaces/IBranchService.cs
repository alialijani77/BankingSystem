using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IBranchService
	{
		Task<IEnumerable<BranchDto>> GetBranch();

		Task<BranchDto> GetBranchById(int branchId);

		Task<bool> AddBranch(AddBranchDto branchDto);

		Task<bool> UpdateBranch(UpdateBranchDto updateBranchDto);

		Task<bool> DeleteBranch(int branchId);

	}
}
