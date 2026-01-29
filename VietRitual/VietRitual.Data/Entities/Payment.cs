using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Payment
{
	[Key]
	public Guid PaymentId { get; set; }

    public Guid OrderId { get; set; }

    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; } = "Pending";

	public string TransactionCode { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual Order Order { get; set; }
}