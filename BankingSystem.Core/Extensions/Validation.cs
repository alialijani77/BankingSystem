using System.Text.RegularExpressions;

namespace BankingSystem.Core.Extensions
{
	public static class Validation
	{
		public static bool ValidateNationalode(this string nationalCode)
		{

			string[] identicalDigits = { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };

			if (string.IsNullOrEmpty(nationalCode.Trim()))
			{
				return false; // National Code is empty
			}
			else if (nationalCode.Length != 10)
			{
				return false; // National Code is less or more than 10 digits
			}
			else if (identicalDigits.Contains(nationalCode))
			{
				return false; // Fake National Code
			}
			else 
			{

				if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
					return false;

				var check = Convert.ToInt32(nationalCode.Substring(9, 1));
				var sum = Enumerable.Range(0, 9)
						.Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
						.Sum() % 11;

				return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
			}
		}
	}
}
