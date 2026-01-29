namespace VietRitual.Data.DTOs
{
	public class DeliveryFeeRuleDTO
	{
		public int RuleId { get; set; }

		public decimal MinDistanceKm { get; set; }

		public decimal MaxDistanceKm { get; set; }

		public decimal FeeAmount { get; set; }

		public bool? IsActive { get; set; }
	}
}
