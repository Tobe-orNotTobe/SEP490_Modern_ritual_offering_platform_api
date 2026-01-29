using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Review
{
	[Key] 
    public int ReviewId { get; set; }

    public Guid OrderId { get; set; }

    public string CustomerProfileId { get; set; }

    public string VendorProfileId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserProfile CustomerProfile { get; set; }

    public virtual Order Order { get; set; }

    public virtual UserProfile VendorProfile { get; set; }
}