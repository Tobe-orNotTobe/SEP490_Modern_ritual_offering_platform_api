using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class WithdrawalRequestRepository : Repository<WithdrawalRequest>, IWithdrawalRequestRepository
	{
		private readonly VietRitualDBContext _context;
		public WithdrawalRequestRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
