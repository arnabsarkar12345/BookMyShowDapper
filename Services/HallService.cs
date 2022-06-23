using BookMyShowAPIDapper.Context;
using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;
using Dapper;
using System.Data;

namespace BookMyShowAPIDapper.Services
{
    public class HallService : IHallService
    {
        private readonly DapperContext _context;
        public HallService(DapperContext context)
        {
            _context = context;
        }

        public async Task<Hall> CreateHall(HallDTO hall)
        {
            var query = "INSERT INTO Hall (HallName, MovieId) VALUES (@HallName, @MovieId)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("TotalSeats", hall.HallName, DbType.String);
            parameters.Add("ShowId", hall.MovieId, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdHall = new Hall
                {
                    HallId = id,
                    HallName = hall.HallName,
                    MovieId = hall.MovieId
                };
                return createdHall;
            }
        }

        public async Task<IEnumerable<Hall>> GetHall(int id)
        {
            var query = "SELECT * FROM Hall where MovieId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var halls = await connection.QueryAsync<Hall>(query, new { id });
                return halls.ToList();
            }
        }

        public async Task<Hall> GetParticularHall(int id)
        {
            var query = "SELECT * FROM Hall WHERE HallId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var hall = await connection.QuerySingleOrDefaultAsync<Hall>(query, new { id });
                return hall;
            }
        }

        public async Task UpdateHall(int id, HallDTO hall)
        {
            var query = "UPDATE Hall SET TotalSeats = @TotalSeats, ShowId = @ShowId WHERE HallId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("TotalSeats", hall.HallName, DbType.String);
            parameters.Add("ShowId", hall.MovieId, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

