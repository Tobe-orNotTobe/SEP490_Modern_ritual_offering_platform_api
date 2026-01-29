namespace VietRitual.Data.DTOs
{
	public class PackageVariantDTO
	{
		public int VariantId { get; set; }

		public int PackageId { get; set; }

		public string VariantName { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public bool? IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }
	}
}
