using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class CulturalGuidelineRepository : Repository<CulturalGuideline>, ICulturalGuidelineRepository
	{
		private readonly VietRitualDBContext _context;
		public CulturalGuidelineRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
