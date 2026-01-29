using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly VietRitualDBContext _context;
		public OrderRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
