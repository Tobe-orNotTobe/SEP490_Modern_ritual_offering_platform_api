using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public partial class CulturalGuideline
{
	[Key]
	public int GuidelineId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CeremonyCategory Category { get; set; }
}