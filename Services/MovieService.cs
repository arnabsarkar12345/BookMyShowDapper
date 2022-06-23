using BookMyShowAPIDapper.Context;
using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;
using Dapper;
using System.Data;

namespace BookMyShowAPIDapper.Services
{
    public class MovieService : IMovieService
    {
        private readonly DapperContext _context;
        public MovieService(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetMovie()
        {
            var query = "SELECT * FROM Movie";
            using (var connection = _context.CreateConnection())
            {
                var movies = await connection.QueryAsync<Movie>(query);
                return movies.ToList();
            }
        }
        public async Task<Movie> GetParticularMovie(int id)
        {
            var query = "SELECT * FROM Movie WHERE MovieId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var movie = await connection.QuerySingleOrDefaultAsync<Movie>(query, new { id });
                return movie;
            }
        }
        public async Task<Movie> CreateMovie(MovieDTO movie)
        {
            var query = "INSERT INTO Movie (Title, Duration, Language, Dimension, Genre, Image, Price) VALUES (@Title, @Duration, @Language, @Dimension, @Genre, @Image, @Price)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", movie.Title, DbType.String);
            parameters.Add("Duration", movie.Duration, DbType.Int64);
            parameters.Add("Language", movie.Language, DbType.String);
            parameters.Add("Dimension", movie.Dimension, DbType.String);
            parameters.Add("Genre", movie.Genre, DbType.String);
            parameters.Add("Image", movie.Image, DbType.String);
            parameters.Add("Price", movie.Price, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdMovie = new Movie                {
                    MovieId = id,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Language = movie.Language,
                    Dimension = movie.Dimension,
                    Genre = movie.Genre,
                    Image = movie.Image,
                    Price = movie.Price
                };
                return createdMovie;
            }
        }
        public async Task UpdateMovie(int id, MovieDTO movie)
        {
            var query = "UPDATE Movie SET Title = @Title, Duration = @Duration, Language = @Language, Dimension = @Dimension, Genre = @Genre, Image = @Image, Price = @Price WHERE MovieId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("MovieId", id, DbType.Int64);
            parameters.Add("Title", movie.Title, DbType.String);
            parameters.Add("Duration", movie.Duration, DbType.Int64);
            parameters.Add("Language", movie.Language, DbType.String);
            parameters.Add("Dimension", movie.Dimension, DbType.String);
            parameters.Add("Genre", movie.Genre, DbType.String);
            parameters.Add("Image", movie.Image, DbType.String);
            parameters.Add("Price", movie.Price, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteMovie(int id)
        {
            var query = "DELETE FROM Movie WHERE MovieId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

    }
}
