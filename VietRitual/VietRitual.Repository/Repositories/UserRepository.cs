using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly VietRitualDBContext _context;
		public UserRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
