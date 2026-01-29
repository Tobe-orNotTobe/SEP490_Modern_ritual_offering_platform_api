using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class OrderDetailService : IOrderDetailService
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderDetailService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
