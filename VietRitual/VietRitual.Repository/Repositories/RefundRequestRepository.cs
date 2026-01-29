using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class RefundRequestRepository : Repository<RefundRequest>, IRefundRequestRepository
	{
		private readonly VietRitualDBContext _context;
		public RefundRequestRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
