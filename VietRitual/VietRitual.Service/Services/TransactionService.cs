using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TransactionService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
