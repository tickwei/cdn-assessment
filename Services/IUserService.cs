using System.Collections.Generic;
using System.Threading.Tasks;
using cdn_assessment.Models;

namespace cdn_assessment.Services
{
    /*Explanation:
        This interface defines the methods that the UserService will implement, 
        which includes methods for getting all users, getting a user by ID, adding, updating, and deleting users.
    */
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
