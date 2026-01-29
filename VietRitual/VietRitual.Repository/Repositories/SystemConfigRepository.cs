using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class SystemConfigRepository : Repository<SystemConfig>, ISystemConfigRepository
	{
		private readonly VietRitualDBContext _context;
		public SystemConfigRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
