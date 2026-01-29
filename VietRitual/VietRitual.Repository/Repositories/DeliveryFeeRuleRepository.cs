using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class DeliveryFeeRuleRepository : Repository<DeliveryFeeRule>, IDeliveryFeeRuleRepository
	{
		private readonly VietRitualDBContext _context;
		public DeliveryFeeRuleRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
