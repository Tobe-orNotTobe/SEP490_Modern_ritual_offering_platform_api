using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class DeliveryFeeRule
{
	[Key]
	public int RuleId { get; set; }

    public decimal MinDistanceKm { get; set; }

    public decimal MaxDistanceKm { get; set; }

    public decimal FeeAmount { get; set; }

    public bool? IsActive { get; set; }
}