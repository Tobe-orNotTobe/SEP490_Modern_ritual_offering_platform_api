using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PaymentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
