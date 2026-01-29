using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class PackageRepository : Repository<Package>, IPackageRepository
	{
		private readonly VietRitualDBContext _context;
		public PackageRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
