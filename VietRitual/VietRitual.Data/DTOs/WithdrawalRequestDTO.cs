namespace VietRitual.Data.DTOs
{
	public class WithdrawalRequestDTO
	{
		public int WithdrawalId { get; set; }

		public int WalletId { get; set; }

		public decimal Amount { get; set; }

		public string BankName { get; set; }

		public string AccountNumber { get; set; }

		public string AccountHolder { get; set; }

		public string Status { get; set; }

		public DateTime? ProcessedDate { get; set; }
	}
}
