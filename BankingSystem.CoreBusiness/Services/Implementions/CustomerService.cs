using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;
using Microsoft.Extensions.Options;


namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class CustomerService : ICustomerService
	{
		private readonly BankingSystemDbContext _context;
		public  readonly OpenAccountDto _openAccountDto;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Branch> _genericRepositoryBranch;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Customer> _genericRepositoryCustmer;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<OpenAccount> _genericRepositoryOpenAccount;



		#region ctor
		public CustomerService(BankingSystemDbContext context, IOptions<OpenAccountDto> openAccountDto)
		{
			_context = context;
			_genericRepositoryBranch = new GenericRepository<Branch>(_context);
			_genericRepositoryCustmer = new GenericRepository<Customer>(_context);
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
				await _genericRepositoryCustmer.Insert(customer);
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
			var getCustomerById = await _genericRepositoryCustmer.GetByID(updateCustomerDto.CustomerId);
			if (getCustomerById != null)
			{
				var updateCustomer = updateCustomerDto.UpdateCustomer(getCustomerById);
				await _genericRepositoryCustmer.Update(updateCustomer);
				return true;
			}
			return false;
		}
		#endregion

		#region DeleteCustomer
		public async Task<bool> DeleteCustomer(long customerId)
		{
			var getcustomerById = await _genericRepositoryCustmer.GetByID(customerId);
			if (getcustomerById != null)
			{
				var deleteCustomer = getcustomerById.DeleteCustomer();
				await _genericRepositoryCustmer.Update(deleteCustomer);
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
				var branch = await _genericRepositoryBranch.GetByID(openAccount.BranchId);
				var branchupdate = branch.UpdateTotalAmountOpenAccount(openAccountDto.TotaAccountBalance);
				await _genericRepositoryBranch.Update(branchupdate);
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
