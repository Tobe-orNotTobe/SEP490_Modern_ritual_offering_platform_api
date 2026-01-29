using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class CeremonyCategoryService : ICeremonyCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CeremonyCategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
