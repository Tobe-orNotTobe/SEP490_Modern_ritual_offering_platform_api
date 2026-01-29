using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class UserProfileService : IUserProfileService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserProfileService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
