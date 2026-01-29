using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class TransactionRepository : Repository<Transaction>, ITransactionRepository
	{
		private readonly VietRitualDBContext _context;
		public TransactionRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
