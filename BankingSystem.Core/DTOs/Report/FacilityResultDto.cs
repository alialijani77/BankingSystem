using BankingSystem.Core.DTOs.Common;
namespace BankingSystem.Core.DTOs.Report
{
	public class FacilityResultDto : Paging<FacilityDto>
	{
		public int DepositFacilityPoints { get; set; }

		public int? BranchId { get; set; }

		public int DepositId { get; set; }

		public DateTime CreateDate { get; set; }

        public int Sort { get; set; }

    }
}
