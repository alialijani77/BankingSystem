namespace BankingSystem.Core.DTOs.Account.Customer
{
	public class CustomerDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string NationalCode { get; set; }

		public string SignatureImage { get; set; }

		public string PhoneNumber { get; set; }

		public int? StateId { get; set; }

		public int? CityId { get; set; }
	}
}
