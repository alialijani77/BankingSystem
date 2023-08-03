namespace BankingSystem.Core.DTOs.Branch
{
	public class UpdateBranchDto
	{
		public int BranchId { get; set; }

		public string BranchName { get; set; }

		public string BranchCode { get; set; }

		public string Address { get; set; }

		public int? StateId { get; set; }

		public int? CityId { get; set; }
	}
}
