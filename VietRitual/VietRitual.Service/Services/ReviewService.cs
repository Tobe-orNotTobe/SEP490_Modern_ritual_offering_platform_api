using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class ReviewService : IReviewService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ReviewService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
