using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class ReviewRepository : Repository<Review>, IReviewRepository
	{
		private readonly VietRitualDBContext _context;
		public ReviewRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
