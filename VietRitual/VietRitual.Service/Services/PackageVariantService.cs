using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class PackageVariantService : IPackageVariantService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PackageVariantService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
