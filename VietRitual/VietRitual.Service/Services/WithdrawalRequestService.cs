using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class WithdrawalRequestService : IWithdrawalRequestService
	{
		private readonly IUnitOfWork _unitOfWork;

		public WithdrawalRequestService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
