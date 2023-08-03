using BankingSystem.Core.DTOs.Account.Customer;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface ICustomerService
	{
		Task<bool> AddCustomer(CustomerDto customerDto);

		Task<bool> UpdateCustomer(UpdateCustomerDto updateCustomerDto);

		Task<bool> DeleteCustomer(int customerId);

		Task<bool> AddOpenAccount(OpenAccountDto openAccountDto);

		Task<bool> DeleteOpenAccount(long openAccountId);
	}
}
