using VietRitual.Data.Entities;

namespace VietRitual.Service.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<User>> GetAllUsers();
		Task<User> GetUserById(string id);
		
	}
}
