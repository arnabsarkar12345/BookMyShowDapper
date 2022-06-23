using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Services;
using Microsoft.AspNetCore.Mvc;
namespace BookMyShowAPIDapper.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovie()
        {
            try
            {
                var movies = await _movieService.GetMovie();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "MovieById")]
        public async Task<IActionResult> GetParticularMovie(int id)
        {
            try
            {
                var movie = await _movieService.GetParticularMovie(id);
                if (movie == null)
                    return NotFound();
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieDTO movie)
        {
            try
            {
                var createdMovie = await _movieService.CreateMovie(movie);
                return CreatedAtRoute("MovieById", new { id = createdMovie.MovieId }, createdMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDTO movie)
        {
            try
            {
                var dbMovie = await _movieService.GetParticularMovie(id);
                if (dbMovie == null)
                    return NotFound();
                await _movieService.UpdateMovie(id, movie);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var dbMovie = await _movieService.GetParticularMovie(id);
                if (dbMovie == null)
                    return NotFound();
                await _movieService.DeleteMovie(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    
}
