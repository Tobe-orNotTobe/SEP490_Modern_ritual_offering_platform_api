namespace VietRitual.Data.DTOs
{
	public class RefundRequestDTO
	{
		public int RefundId { get; set; }

		public Guid OrderId { get; set; }

		public Guid CustomerProfileId { get; set; }

		public string Reason { get; set; }

		public string ProofImage { get; set; }

		public decimal Amount { get; set; }

		public string Status { get; set; }

		public string AdminResponse { get; set; }

		public DateTime? ResolvedAt { get; set; }
	}
}
