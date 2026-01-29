using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		private readonly VietRitualDBContext _context;
		public OrderDetailRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
