using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class Notification
{
	[Key]
	public int NotificationId { get; set; }

    public string UserId { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual User User { get; set; }
}