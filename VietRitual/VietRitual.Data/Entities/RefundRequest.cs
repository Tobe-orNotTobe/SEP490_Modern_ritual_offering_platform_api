using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class RefundRequest
{
	[Key]
	public int RefundId { get; set; }

    public Guid OrderId { get; set; }

    public string CustomerProfileId { get; set; }

    public string Reason { get; set; }

    public string ProofImage { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = "Pending";

    public string AdminResponse { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public virtual UserProfile CustomerProfile { get; set; }

    public virtual Order Order { get; set; }
}