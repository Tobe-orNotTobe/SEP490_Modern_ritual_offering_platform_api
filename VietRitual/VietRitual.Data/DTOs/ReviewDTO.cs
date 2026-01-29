namespace VietRitual.Data.DTOs
{
	public class ReviewDTO
	{
		public int ReviewId { get; set; }

		public Guid OrderId { get; set; }

		public string CustomerProfileId { get; set; }

		public string VendorProfileId { get; set; }

		public int Rating { get; set; }

		public string Comment { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
