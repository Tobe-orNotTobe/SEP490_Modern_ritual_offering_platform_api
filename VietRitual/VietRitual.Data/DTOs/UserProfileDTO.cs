namespace VietRitual.Data.DTOs
{
	public class UserProfileDTO
	{
		public string ProfileId { get; set; }

		public string UserId { get; set; }

		public string FullName { get; set; }

		public string Phone { get; set; }

		public string AvatarUrl { get; set; }

		public string Gender { get; set; }

		public DateOnly? DateOfBirth { get; set; }

		public string AddressText { get; set; }

		public decimal? Latitude { get; set; }

		public decimal? Longitude { get; set; }

		public bool? IsVendor { get; set; }

		public string? ShopName { get; set; }

		public string? BusinessLicenseNo { get; set; }

		public string? VerificationStatus { get; set; }

		public decimal? RatingAvg { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }
	}
}
