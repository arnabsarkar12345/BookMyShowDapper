using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;

namespace BookMyShowAPIDapper.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetMovie();
        public Task<Movie> GetParticularMovie(int id);
        public Task<Movie> CreateMovie(MovieDTO movie);
        public Task UpdateMovie(int id, MovieDTO movie);
        public Task DeleteMovie(int id);
    }
}
