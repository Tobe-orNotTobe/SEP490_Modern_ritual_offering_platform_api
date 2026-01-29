namespace VietRitual.Data.DTOs
{
	public class OrderDetailDTO
	{
		public Guid DetailId { get; set; }

		public Guid OrderId { get; set; }

		public int VariantId { get; set; }

		public string DecorationNote { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}
}
