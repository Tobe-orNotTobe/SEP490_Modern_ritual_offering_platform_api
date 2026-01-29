using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class WithdrawalRequest
{
	[Key]
	public int WithdrawalId { get; set; }

    public int WalletId { get; set; }

    public decimal Amount { get; set; }

    public string BankName { get; set; }

    public string AccountNumber { get; set; }

    public string AccountHolder { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime? ProcessedDate { get; set; }

    public virtual Wallet Wallet { get; set; }
}