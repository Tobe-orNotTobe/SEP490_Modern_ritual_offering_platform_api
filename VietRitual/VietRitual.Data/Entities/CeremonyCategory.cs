using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class CeremonyCategory
{
	[Key]
	public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CulturalGuideline> CulturalGuidelines { get; set; } = new List<CulturalGuideline>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}