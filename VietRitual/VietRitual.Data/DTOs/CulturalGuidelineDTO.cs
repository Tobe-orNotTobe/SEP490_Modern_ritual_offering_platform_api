namespace VietRitual.Data.DTOs
{
	public class CulturalGuidelineDTO
	{
		public int GuidelineId { get; set; }

		public int CategoryId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
