using BookMyShowAPIDapper.Context;
using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;
using Dapper;
using System.Data;

namespace BookMyShowAPIDapper.Services
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;
        public UserService(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            var query = "SELECT * FROM [User]";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users.ToList();
            }
        }
        public async Task<User> GetParticularUser(int id)
        {
            var query = "SELECT * FROM [User] WHERE UserId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
                return user;
            }
        }
        public async Task<User> CreateUser(UserDTO user)
        {
            var query = "INSERT INTO [User] (Name, Email, Mobile, City) VALUES (@Name, @Email, @Mobile, @City)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", user.Name, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Mobile", user.Mobile, DbType.String);
            parameters.Add("City", user.City, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdUser = new User
                {
                    UserId = id,
                    Name = user.Name,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    City = user.City,
                };
                return createdUser;
            }

        }
        public async Task UpdateUser(int id, UserDTO user)
        {
            var query = "UPDATE [User] SET Name = @Name, Email = @Email, Mobile = @Mobile, City = @City WHERE UserId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Name", user.Name, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Mobile", user.Mobile, DbType.String);
            parameters.Add("City", user.City, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteUser(int id)
        {
            var query = "DELETE FROM [User] WHERE UserId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        

        

        
    }
}
