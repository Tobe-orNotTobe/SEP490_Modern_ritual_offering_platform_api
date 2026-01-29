using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class PackageVariant
{
	[Key]
	public int VariantId { get; set; }

    public int PackageId { get; set; }

    public string VariantName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Package Package { get; set; }
}