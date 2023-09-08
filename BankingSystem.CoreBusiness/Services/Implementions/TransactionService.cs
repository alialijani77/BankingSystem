using BankingSystem.Core.DTOs.Transaction;
using BankingSystem.Core.Extensions;
using BankingSystem.Core.Statics;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Account.Customer;
using BankingSystem.Domain.Entities.Branch;
using BankingSystem.Domain.Entities.Transaction;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class TransactionService : ITransactionService
	{
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Branch> _genericRepositoryBranch;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Customer> _genericRepositoryCustomer;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<OpenAccount> _genericRepositoryOpenAccount;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Transaction> _genericRepositoryTransaction;


		public TransactionService(BankingSystemDbContext context)
		{
			_context = context;
			_genericRepositoryBranch = new GenericRepository<Branch>(_context);
			_genericRepositoryCustomer = new GenericRepository<Customer>(_context);
			_genericRepositoryOpenAccount = new GenericRepository<OpenAccount>(_context);
			_genericRepositoryTransaction = new GenericRepository<Transaction>(_context);


		}
		public async Task<TransactionResultDtos> Transfer(TransactionDtos transactionDtos)
		{
			var openAccountBySrcCardNumber = _genericRepositoryOpenAccount.Get(o => o.CardNumber == transactionDtos.SrcCardNumber, null, "Deposit").FirstOrDefault();
			if (openAccountBySrcCardNumber != null)
			{
				var result = TransactionStatics.Transfer_rq_val(transactionDtos, openAccountBySrcCardNumber);
				if (result.IsSuccess == true)
				{
					//update openAccountBySrcCardNumber
					var openAccountSrc = openAccountBySrcCardNumber.UpdateSrcOpenAccount(transactionDtos.Amount);
					await _genericRepositoryOpenAccount.Update(openAccountSrc);
					//update BranchSrcAmount
					var getSrcBranch = await _genericRepositoryBranch.GetByID(openAccountBySrcCardNumber.BranchId);
					var branchSrcUpdate = getSrcBranch.UpdateBranchAfterSrcTransaction(transactionDtos.Amount);
					await _genericRepositoryBranch.Update(branchSrcUpdate);
					//update CustomerSrcAmount
					var getSrcCustomer = await _genericRepositoryCustomer.GetByID(openAccountBySrcCardNumber.CustomerId);
					var customerSrcUpdate = getSrcCustomer.UpdateCustomerAfterSrcTransaction(transactionDtos.Amount);
					await _genericRepositoryCustomer.Update(customerSrcUpdate);
					//check openAccountByDstCardNumber
					var openAccountByDstCardNumber = _genericRepositoryOpenAccount.Get(o => o.CardNumber == transactionDtos.DstCardNumber, null, "Deposit").FirstOrDefault();
					if (openAccountByDstCardNumber != null)
					{
						//update openAccountByDstCardNumber
						var openAccountDst = openAccountByDstCardNumber.UpdateDstOpenAccount(transactionDtos.Amount);
						await _genericRepositoryOpenAccount.Update(openAccountDst);
						//add into transaction
						var transaction = transactionDtos.NewTransaction();
						if (transaction != null)
						{
							await _genericRepositoryTransaction.Insert(transaction);
							//update BranchDstAmount
							var getDstBranch = await _genericRepositoryBranch.GetByID(openAccountByDstCardNumber.BranchId);
							var branchDstUpdate = getDstBranch.UpdateBranchAfterDstTransaction(transactionDtos.Amount);
							await _genericRepositoryBranch.Update(branchDstUpdate);
							//update CustomerDstAmount
							var getDstCustomer = await _genericRepositoryCustomer.GetByID(openAccountByDstCardNumber.CustomerId);
							var customerDstUpdate = getDstCustomer.UpdateCustomerAfterDstTransaction(transactionDtos.Amount);
							await _genericRepositoryCustomer.Update(customerDstUpdate);
							return result;
						}
					}
				}
				return result;
			}
			return new TransactionResultDtos() { Message = "اطلاعات کارت وارد شده اشتباه است.", IsSuccess = false };
		}

		public async Task<string> GetOtp(GetOtpDtos getOtp)
		{
			var openAccountBySrcCardNumber = _genericRepositoryOpenAccount.Get(o => o.CardNumber == getOtp.SrcCardNumber, null, "").FirstOrDefault();
			if (openAccountBySrcCardNumber != null)
			{
				var updateOtp = openAccountBySrcCardNumber.UpdateOtp(getOtp);
				await _genericRepositoryOpenAccount.Update(updateOtp);
				return updateOtp.Otp;
			}
				return null;
		}

		public async Task<string> GetShaba(GetShabaDtos getShaba)
		{
			var getShabaByCardNumber = _genericRepositoryOpenAccount.Get(o => o.CardNumber == getShaba.CardNumber, null, "").Select(o => o.Shaba).FirstOrDefault();
			if (getShabaByCardNumber != null)
			{
				return getShabaByCardNumber;
			}
			return null;
		}
	}
}
