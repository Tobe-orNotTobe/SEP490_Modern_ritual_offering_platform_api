using Microsoft.AspNetCore.Identity;
using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class RoleRepository : Repository<IdentityRole>, IRoleRepository
	{
		private readonly VietRitualDBContext _context;
		public RoleRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
