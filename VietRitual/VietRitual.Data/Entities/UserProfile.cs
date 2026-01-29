using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class UserProfile
{
	[Key]
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

    public string ShopName { get; set; }

    public string BusinessLicenseNo { get; set; }

    public string VerificationStatus { get; set; }

    public decimal? RatingAvg { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> OrderCustomerProfiles { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderVendorProfiles { get; set; } = new List<Order>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();

    public virtual ICollection<Review> ReviewCustomerProfiles { get; set; } = new List<Review>();

    public virtual ICollection<Review> ReviewVendorProfiles { get; set; } = new List<Review>();

    public virtual User User { get; set; }
}