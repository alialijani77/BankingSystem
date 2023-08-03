using BankingSystem.Core.DTOs.Branch;
using BankingSystem.Domain.Entities.Branch;

namespace BankingSystem.Core.Extensions
{
	public static class BranchExtensions
	{
		#region Branch
		public static BranchDto GetBranchById(this Branch branch)
		{
			var branchDto = new BranchDto();
			branchDto.BranchName = branch.BranchName;
			branchDto.BranchCode = branch.BranchCode;
			branchDto.Address = branch.Address;
			return branchDto;
		}

		public static Branch NewBranch(this BranchDto branchDto)
		{
			var branch = new Branch();
			branch.BranchName = branchDto.BranchName;
			branch.BranchCode = branchDto.BranchCode;
			branch.StateId = branchDto.StateId;
			branch.CityId = branchDto.CityId;
			branch.Address = branchDto.Address;
			return branch;
		}

		public static Branch UpdateBranch(this UpdateBranchDto updateBranchDto,Branch branch)
		{
			branch.BranchName = updateBranchDto.BranchName;
			branch.BranchCode = updateBranchDto.BranchCode;
			branch.StateId = updateBranchDto.StateId;
			branch.CityId = updateBranchDto.CityId;
			branch.Address = updateBranchDto.Address;
			branch.CreateDate = DateTime.Now;
			return branch;
		}

		public static Branch DeleteBranch(this Branch branch)
		{
			branch.IsDelete = true;
			branch.CreateDate = DateTime.Now;
			return branch;
		}
		#endregion
	}
}
