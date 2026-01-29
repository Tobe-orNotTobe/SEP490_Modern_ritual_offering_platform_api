using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class RefundRequestService : IRefundRequestService
	{
		private readonly IUnitOfWork _unitOfWork;

		public RefundRequestService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
