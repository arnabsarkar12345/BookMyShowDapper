using BookMyShowAPIDapper.Context;
using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;
using Dapper;
using System.Data;

namespace BookMyShowAPIDapper.Services
{
    public class ShowService : IShowService
    {
        private readonly DapperContext _context;
        public ShowService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Show>> GetShow()
        {
            var query = "SELECT * FROM Show";
            using (var connection = _context.CreateConnection())
            {
                var shows = await connection.QueryAsync<Show>(query);
                return shows.ToList();
            }
        }

        public async Task<IEnumerable<Show>> GetShows(int id)
        {
            var query = "SELECT * FROM Show WHERE MovieId = @Id";
            //using (var connection = _context.CreateConnection())
            //{
            //    var show = await connection.QuerySingleOrDefaultAsync<Show>(query, new { id });
            //    return show;
            //}
            using (var connection = _context.CreateConnection())
            {
                var shows = await connection.QueryAsync<Show>(query, new { id });
                return shows.ToList();
            }
        }

        public async Task<Show> CreateShow(ShowDTO show)
        {
            var query = "INSERT INTO Show (StartTime, EndTime, Date, HallId, MovieId) VALUES (@StartTime, @EndTime, @Date, @HallId, @MovieId)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("StartTime", show.StartTime, DbType.String);
            parameters.Add("EndTime", show.EndTime, DbType.String);
            parameters.Add("Date", show.Date, DbType.String);
            parameters.Add("HallId", show.HallId, DbType.Int64);
            parameters.Add("MovieId", show.MovieId, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdShow = new Show
                {
                    ShowId = id,
                    StartTime = show.StartTime,
                    EndTime = show.EndTime,
                    Date = show.Date,
                    HallId = show.HallId,
                    MovieId = show.MovieId
                };
                return createdShow;
            }
        }

        public async Task DeleteShow(int id)
        {
            var query = "DELETE FROM Show WHERE ShowId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Show> GetParticularShow(int id)
        {
            var query = "SELECT * from Show WHERE ShowId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var show = await connection.QuerySingleOrDefaultAsync<Show>(query, new { id });
                return show;
            }
        }
    }
}
