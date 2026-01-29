using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class NotificationRepository : Repository<Notification>, INotificationRepository
	{
		private readonly VietRitualDBContext _context;
		public NotificationRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
