namespace VietRitual.Data.DTOs
{
	public class PackageDTO
	{
		public int PackageId { get; set; }

		public string VendorProfileId { get; set; }

		public int CategoryId { get; set; }

		public string PackageName { get; set; }

		public string Description { get; set; }

		public bool? IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
