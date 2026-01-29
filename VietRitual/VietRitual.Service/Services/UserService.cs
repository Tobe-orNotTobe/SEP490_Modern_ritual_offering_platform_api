using VietRitual.Data.Entities;
using VietRitual.Repository.Interfaces;
using VietRitual.Service.Interfaces;

namespace VietRitual.Service.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Task<IEnumerable<User>> GetAllUsers()
		{
			return _unitOfWork.Users.GetAllAsync();
		}
		public Task<User> GetUserById(string id)
		{
			return _unitOfWork.Users.GetAsync(u => u.Id == id);
		}
		
	}
}
