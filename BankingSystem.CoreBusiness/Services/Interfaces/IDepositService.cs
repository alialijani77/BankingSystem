using BankingSystem.Core.DTOs.Deposit;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IDepositService
	{
		Task<bool> AddDeposit(DepsoitDto depsoitDto);

		Task<bool> UpdateDeposit(UpdateDepsoitDto updateDepsoitDto);

		Task<bool> DeleteDeposit(int depsoitId);
	}
}
