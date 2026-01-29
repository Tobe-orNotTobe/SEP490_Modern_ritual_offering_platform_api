using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class CulturalGuidelineService : ICulturalGuidelineService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CulturalGuidelineService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
