namespace VietRitual.Data.DTOs
{
	public class NotificationDTO
	{
		public int NotificationId { get; set; }

		public Guid UserId { get; set; }

		public string Title { get; set; }

		public string Message { get; set; }

		public bool? IsRead { get; set; }

		public DateTime? CreateAt { get; set; }
	}
}
