using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Transaction
{
	[Key]
	public int TransactionId { get; set; }

    public int WalletId { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string ReferenceId { get; set; }

    public virtual Wallet Wallet { get; set; }
}