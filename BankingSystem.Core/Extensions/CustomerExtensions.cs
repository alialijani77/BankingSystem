using BankingSystem.Core.DTOs.Account.Customer;
using BankingSystem.Core.Generator;
using BankingSystem.Domain.Entities.Account.Customer;

namespace BankingSystem.Core.Extensions
{
	public static class CustomerExtensions
	{

		#region Customer
		public static Customer NewCustomer(this CustomerDto customerDto)
		{
			var customer = new Customer();
			customer.FirstName = customerDto.FirstName;
			customer.LastName = customerDto.LastName;
			customer.NationalCode = customerDto.NationalCode;
			customer.PhoneNumber = customerDto.PhoneNumber;
			customer.SignatureImage = customerDto.SignatureImage;
			customer.StateId = customerDto.StateId;
			customer.CityId = customerDto.CityId;
			return customer;
		}

		public static Customer UpdateCustomer(this UpdateCustomerDto customerDto, Customer customer)
		{
			customer.FirstName = customerDto.FirstName;
			customer.LastName = customerDto.LastName;
			customer.NationalCode = customerDto.NationalCode;
			customer.PhoneNumber = customerDto.PhoneNumber;
			customer.SignatureImage = customerDto.SignatureImage;
			customer.StateId = customerDto.StateId;
			customer.CityId = customerDto.CityId;
			customer.CreateDate = DateTime.Now;

			return customer;
		}

		public static Customer DeleteCustomer(this Customer customer)
		{
			customer.IsDelete = true;
			customer.CreateDate = DateTime.Now;
			return customer;
		}
		#endregion

		#region OpenAccount
		public static OpenAccount NewOpenAccount(this OpenAccountDto openAccountDto)
		{
			var openAccount = new OpenAccount();
			openAccount.BranchId = openAccountDto.BranchId;
			openAccount.DepositId = openAccountDto.DepositId;
			openAccount.CustomerId = openAccountDto.CustomerId;
			openAccount.AccountNumber = RandomGenerator.AccountNumberGenerator(openAccountDto.BranchId, openAccountDto.DepositId, openAccountDto.CustomerId);
			openAccount.CardNumber = RandomGenerator.CardNumberGenerator();
			openAccount.Cvv2 = RandomGenerator.Cvv2Generator();
			openAccount.Expmonth = DateTime.Now.GetPersianMonth();
			openAccount.ExpYear = Convert.ToString(Convert.ToInt16(DateTime.Now.GetPersianYear()) + openAccountDto.ExpDate).Length == 1 ? "0" + Convert.ToString(Convert.ToInt16(DateTime.Now.GetPersianYear()) + openAccountDto.ExpDate) : Convert.ToString(Convert.ToInt16(DateTime.Now.GetPersianYear()) + openAccountDto.ExpDate);
			openAccount.CardPassword = RandomGenerator.CardPassword();
			openAccount.Shaba = RandomGenerator.ShabaGenerator(openAccount.AccountNumber);
			openAccount.TotaAccountBalance = openAccount.TotaAccountBalance;
			return openAccount;
		}
		public static OpenAccount UpdateSrcOpenAccount(this OpenAccount openAccount,long Amount)
		{
			openAccount.TotaAccountBalance -= Amount;
			openAccount.WithdrawToAccountCount += 1;
			openAccount.DepositFacilityPoints = (openAccount.WithdrawToAccountCount / 10 == 0) ? openAccount.DepositFacilityPoints += 1 : openAccount.DepositFacilityPoints;
			openAccount.CreateDate = DateTime.Now;
			openAccount.Otp = "";
			return openAccount;
		}

		public static OpenAccount UpdateDstOpenAccount(this OpenAccount openAccount, long Amount)
		{
			openAccount.TotaAccountBalance += Amount;
			openAccount.DepositToAccountCount += 1;
			openAccount.CreateDate = DateTime.Now;

			return openAccount;
		}

		public static OpenAccount DeleteOpenAccount(this OpenAccount openAccount)
		{
			openAccount.IsDelete = true;
			openAccount.CreateDate = DateTime.Now;
			return openAccount;
		}
		#endregion
	}
}
