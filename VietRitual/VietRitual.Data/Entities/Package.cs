using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Package
{
	[Key]
	public int PackageId { get; set; }

    public string VendorProfileId { get; set; }

    public int CategoryId { get; set; }

    public string PackageName { get; set; }

    public string Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CeremonyCategory Category { get; set; }

    public virtual ICollection<PackageVariant> PackageVariants { get; set; } = new List<PackageVariant>();

    public virtual UserProfile VendorProfile { get; set; }
}