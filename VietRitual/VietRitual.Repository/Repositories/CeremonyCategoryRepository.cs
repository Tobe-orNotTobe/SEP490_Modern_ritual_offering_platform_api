using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class CeremonyCategoryRepository : Repository<CeremonyCategory>, ICeremonyCategoryRepository
	{
		private readonly VietRitualDBContext _context;
		public CeremonyCategoryRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}