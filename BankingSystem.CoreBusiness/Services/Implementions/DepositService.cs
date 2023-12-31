﻿using BankingSystem.Core.DTOs.Deposit;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Deposit;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

namespace BankingSystem.CoreBusiness.Services.Implementions
{
	public class DepositService : IDepositService
	{
		private readonly BankingSystemDbContext _context;
		private readonly Domain.Interfaces.GenericRepository.IGenericRepository<Deposit> _genericRepository;

		#region ctor
		public DepositService(BankingSystemDbContext context)
		{
			_context = context;
			_genericRepository = new GenericRepository<Deposit>(_context);
		}
		#endregion

		#region GetDeposit
		public async Task<IEnumerable<DepositDto>> GetDeposit()
		{
			var depsoit = _genericRepository.Get(u => u.DepositId != null, null, "");
			if (depsoit != null)
			{
				return depsoit.GetDeposit();
			}
			return null;
		}
		#endregion

		#region GetDepositById
		public async Task<DepositDto> GetDepositById(int depositId)
		{
			var deposit = await _genericRepository.GetByID(depositId);
			if (deposit != null)
			{
				return deposit.GetDepositById();
			}
			return null;
		}
		#endregion

		#region AddDeposit
		public async Task<bool> AddDeposit(AddDepsoitDto depsoitDto)
		{
			var depsoit = depsoitDto.NewDepsoit();
			if (depsoit != null)
			{
				await _genericRepository.Insert(depsoit);
				return true;
			}
			return false;
		}
		#endregion

		#region UpdateDeposit
		public async Task<bool> UpdateDeposit(UpdateDepsoitDto updateDepsoitDto)
		{
			var getDepositById = await _genericRepository.GetByID(updateDepsoitDto.DepositId);
			if (getDepositById != null)
			{
				var updateDeposit = updateDepsoitDto.UpdateDepsoit(getDepositById);
				await _genericRepository.Update(updateDeposit);
				return true;
			}
			return false;
		}
		#endregion

		#region DeleteDeposit
		public async Task<bool> DeleteDeposit(int depsoitId)
		{
			var getDepositById = await _genericRepository.GetByID(depsoitId);
			if (getDepositById != null)
			{
				var deleteBranch = getDepositById.DeleteDeposit();
				await _genericRepository.Update(deleteBranch);
				return true;
			}
			return false;
		}
		#endregion
	}
}
