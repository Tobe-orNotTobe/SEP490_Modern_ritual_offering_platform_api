using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
	{
		private readonly VietRitualDBContext _context;
		public UserProfileRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
