using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class User : IdentityUser
{
    public string Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}