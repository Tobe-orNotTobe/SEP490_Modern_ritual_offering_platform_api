using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class OrderDetail
{
	[Key]
	public Guid DetailId { get; set; }

    public Guid OrderId { get; set; }

    public int VariantId { get; set; }

    public string DecorationNote { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order Order { get; set; }

    public virtual PackageVariant Variant { get; set; }
}