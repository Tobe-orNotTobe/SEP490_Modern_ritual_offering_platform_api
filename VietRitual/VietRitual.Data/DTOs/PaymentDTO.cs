namespace VietRitual.Data.DTOs
{
	public class PaymentDTO
	{
		public Guid PaymentId { get; set; }

		public Guid OrderId { get; set; }

		public string PaymentMethod { get; set; }

		public string PaymentStatus { get; set; }

		public string TransactionCode { get; set; }

		public DateTime? PaidAt { get; set; }
	}
}
