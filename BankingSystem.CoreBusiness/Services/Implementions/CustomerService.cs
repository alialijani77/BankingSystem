using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;
using Microsoft.Extensions.Options;


namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class CustomerService : ICustomerService
	{
		private readonly BankingSystemDbContext _context;
		public  readonly OpenAccountDto _openAccountDto;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Customer> _genericRepository;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<OpenAccount> _genericRepositoryOpenAccount;



		#region ctor
		public CustomerService(BankingSystemDbContext context, IOptions<OpenAccountDto> openAccountDto)
		{
			_context = context;
			_genericRepository = new GenericRepository<Customer>(_context);
			_genericRepositoryOpenAccount = new GenericRepository<OpenAccount>(_context);
			_openAccountDto = openAccountDto.Value;

		}
		#endregion

		#region Customer

		#region AddCustomer
		public async Task<bool> AddCustomer(CustomerDto customerDto)
		{
			if (customerDto.NationalCode.ValidateNationalode())
			{
				return false;
			}
			var customer = customerDto.NewCustomer();
			if (customer != null)
			{
				await _genericRepository.Insert(customer);
				return true;
			}
			return false;
		}
		#endregion

		#region UpdateCustomer
		public async Task<bool> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
		{
			if (updateCustomerDto.NationalCode.ValidateNationalode())
			{
				return false;
			}
			var getCustomerById = await _genericRepository.GetByID(updateCustomerDto.CustomerId);
			if (getCustomerById != null)
			{
				var updateCustomer = updateCustomerDto.UpdateCustomer(getCustomerById);
				await _genericRepository.Update(updateCustomer);
				return true;
			}
			return false;
		}
		#endregion

		#region DeleteCustomer
		public async Task<bool> DeleteCustomer(int customerId)
		{
			var getcustomerById = await _genericRepository.GetByID(customerId);
			if (getcustomerById != null)
			{
				var deleteCustomer = getcustomerById.DeleteCustomer();
				await _genericRepository.Update(deleteCustomer);
				return true;
			}
			return false;
		}
		#endregion

		#endregion

		#region OpenAccount

		#region AddOpenAccount
		public async Task<bool> AddOpenAccount(OpenAccountDto openAccountDto)
		{

			openAccountDto.ExpDate = _openAccountDto.ExpDate;
			var openAccount = openAccountDto.NewOpenAccount();
			var openAccountByCardNumber = _genericRepositoryOpenAccount.Get(u => u.CardNumber == openAccount.CardNumber, null, "").FirstOrDefault();
			if (openAccount != null && openAccountByCardNumber == null)
			{
				await _genericRepositoryOpenAccount.Insert(openAccount);
				return true;
			}
			return false;
		}
		#endregion

		#region DeleteOpenAccount
		public async Task<bool> DeleteOpenAccount(long openAccountId)
		{
			var getOpenAccountById = await _genericRepositoryOpenAccount.GetByID(openAccountId);
			if (getOpenAccountById != null)
			{
				var deleteOpenAccount = getOpenAccountById.DeleteOpenAccount();
				await _genericRepositoryOpenAccount.Update(deleteOpenAccount);
				return true;
			}
			return false;
		}
		#endregion

		#endregion
	}
}
