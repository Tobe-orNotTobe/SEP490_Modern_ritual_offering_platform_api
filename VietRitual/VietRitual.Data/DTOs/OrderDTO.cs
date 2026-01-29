namespace VietRitual.Data.DTOs
{
	public class OrderDTO
	{
		public Guid OrderId { get; set; }

		public string CustomerProfileId { get; set; }

		public string VendorProfileId { get; set; }

		public string OrderStatus { get; set; }

		public DateOnly DeliveryDate { get; set; }

		public TimeOnly DeliveryTime { get; set; }

		public string DeliveryAddress { get; set; }

		public decimal? ShippingDistanceKm { get; set; }

		public decimal? ShippingFee { get; set; }

		public decimal? CommissionRate { get; set; }

		public decimal? PlatformFee { get; set; }

		public decimal TotalAmount { get; set; }

		public decimal VendorNetAmount { get; set; }

		public bool? IsPaidToVendor { get; set; }

		public DateTime? PaidToVendorDate { get; set; }

		public decimal? RefundAmount { get; set; }

		public string? CancelReason { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
