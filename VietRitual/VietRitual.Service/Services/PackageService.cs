using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class PackageService : IPackageService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PackageService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
