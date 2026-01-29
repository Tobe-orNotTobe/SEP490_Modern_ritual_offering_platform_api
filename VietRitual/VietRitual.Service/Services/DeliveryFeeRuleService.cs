using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class DeliveryFeeRuleService : IDeliveryFeeRuleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeliveryFeeRuleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
