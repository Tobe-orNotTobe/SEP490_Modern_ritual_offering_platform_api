using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class WalletRepository : Repository<Wallet>, IWalletRepository
	{
		private readonly VietRitualDBContext _context;
		public WalletRepository(VietRitualDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
