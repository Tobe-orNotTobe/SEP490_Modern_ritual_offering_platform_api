namespace VietRitual.Data.DTOs
{
	public class UserDTO
	{
		public string UserId { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public string Status { get; set; }

		public DateTime? CreateAt { get; set; }

	}
}
