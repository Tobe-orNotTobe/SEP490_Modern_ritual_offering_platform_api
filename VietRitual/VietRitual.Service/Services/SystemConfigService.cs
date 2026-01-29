using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class SystemConfigService : ISystemConfigService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SystemConfigService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
