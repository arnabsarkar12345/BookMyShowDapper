using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPIDapper.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;
        public ShowController(IShowService showService)
        {
            _showService = showService;
        }
        [HttpGet]
        public async Task<IActionResult> GetShow()
        {
            try
            {
                var shows = await _showService.GetShow();
                return Ok(shows);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{movieId}", Name = "ShowByMovieId")]
        public async Task<IActionResult> GetShows(int movieId)
        {
            try
            {
                var show = await _showService.GetShows(movieId);
                if (show == null)
                    return NotFound();
                return Ok(show);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("booking/{id}", Name = "ShowById")]
        public async Task<IActionResult> GetParticularShow(int id)
        {
            try
            {
                var show = await _showService.GetParticularShow(id);
                if (show == null)
                    return NotFound();
                return Ok(show);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow(ShowDTO show)
        {
            try
            {
                var createdShow = await _showService.CreateShow(show);
                return CreatedAtRoute("ShowById", new { id = createdShow.ShowId }, createdShow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            try
            {
                var dbShow = await _showService.GetParticularShow(id);
                if (dbShow == null)
                    return NotFound();
                await _showService.DeleteShow(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
