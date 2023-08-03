using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Core.DTOs.Branch
{
	public class BranchDto
	{
		[MaxLength(10)]
		public string BranchName { get; set; }

		public string BranchCode { get; set; }

		public string Address { get; set; }

		public int? StateId { get; set; }

		public int? CityId { get; set; }
	}
}
