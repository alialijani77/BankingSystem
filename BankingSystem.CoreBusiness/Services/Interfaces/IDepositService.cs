using BankingSystem.Core.DTOs.Deposit;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IDepositService
	{
		Task<IEnumerable<DepositDto>> GetDeposit();

		Task<DepositDto> GetDepositById(int depositId);

		Task<bool> AddDeposit(AddDepsoitDto depsoitDto);

		Task<bool> UpdateDeposit(UpdateDepsoitDto updateDepsoitDto);

		Task<bool> DeleteDeposit(int depsoitId);
	}
}
