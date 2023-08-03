namespace BankingSystem.Core.Generator
{
	public static class RandomGenerator
	{
		public static string AccountNumberGenerator(int branchId, int depositId, long customerId)
		{
			Random rnd = new Random();
			return $"{branchId}{depositId}{customerId}{rnd.Next(1, 9)}";
		}

		public static string CardNumberGenerator()
		{
			Random rnd = new Random();
			int cardNumber1 = rnd.Next(5022, 5024);
			int cardNumber2 = rnd.Next(2910, 3910);
			int cardNumber3 = rnd.Next(2000, 9999);
			int cardNumber4 = rnd.Next(1111, 9999);
			var CreditCardNumber = $"{cardNumber1}{cardNumber2}{cardNumber3}{cardNumber4}";
			return CreditCardNumber;
		}

		public static int Cvv2Generator()
		{
			Random rnd = new Random();
			int cvv2 = rnd.Next(100, 999);
			return cvv2;
		}

		public static int CardPassword()
		{
			Random rnd = new Random();
			int cardPassword = rnd.Next(1000, 9999);
			return cardPassword;
		}

		public static string ShabaGenerator(string AccountNumber)
		{
			string shaba = $"IR{AccountNumber}";
			for (int i = 0; i < 24 - AccountNumber.Length; i++)
			{
				shaba = shaba.Insert(shaba.IndexOf("R") + 1, "0");

			}
			return shaba;
		}

		public static int TrnSeq()
		{
			Random rnd = new Random();
			int TrnSeq = rnd.Next(1000, 999999);
			return TrnSeq;
		}
	}
}
