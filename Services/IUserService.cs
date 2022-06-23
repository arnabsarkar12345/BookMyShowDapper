using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;

namespace BookMyShowAPIDapper.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUser();
        public Task<User> GetParticularUser(int id);
        public Task<User> CreateUser(UserDTO user);
        public Task UpdateUser(int id, UserDTO user);
        public Task DeleteUser(int id);
    }
}
