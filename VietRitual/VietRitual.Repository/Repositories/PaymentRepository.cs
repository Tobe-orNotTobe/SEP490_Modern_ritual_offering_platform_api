using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class PaymentRepository : Repository<Payment>, IPaymentRepository
	{
		private readonly VietRitualDBContext _context;
		public PaymentRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
