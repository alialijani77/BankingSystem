using BankingSystem.Core.DTOs.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.CoreBusiness.Services.Interfaces
{
	public interface IReportService
	{
		Task<CalculateDepositInterestResultDto> GetCalculateDepositInterest(CalculateDepositInterestDto calculateDepositInterestDto);
	}
}
