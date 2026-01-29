using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class PackageVariantRepository : Repository<PackageVariant>, IPackageVariantRepository
	{
		private readonly VietRitualDBContext _context;
		public PackageVariantRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
