using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Wallet
{
	[Key]
	public int WalletId { get; set; }

    public string UserId { get; set; }

    public decimal? Balance { get; set; }

    public decimal? HeldBalance { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; }

    public virtual ICollection<WithdrawalRequest> WithdrawalRequests { get; set; } = new List<WithdrawalRequest>();
}