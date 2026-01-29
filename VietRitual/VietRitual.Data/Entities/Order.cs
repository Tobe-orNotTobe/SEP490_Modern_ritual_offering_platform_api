using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Order
{
	[Key]
	public Guid OrderId { get; set; }

    public string CustomerProfileId { get; set; }

    public string VendorProfileId { get; set; }

    public string OrderStatus { get; set; } = "Pending";

	public DateOnly DeliveryDate { get; set; }

    public TimeOnly DeliveryTime { get; set; }

    public string DeliveryAddress { get; set; }

    public decimal ShippingDistanceKm { get; set; }

    public decimal ShippingFee { get; set; }

    public decimal CommissionRate { get; set; }

    public decimal PlatformFee { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal VendorNetAmount { get; set; }

    public bool? IsPaidToVendor { get; set; }

    public DateTime? PaidToVendorDate { get; set; }

    public decimal? RefundAmount { get; set; }

    public string? CancelReason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserProfile CustomerProfile { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual UserProfile VendorProfile { get; set; }
}