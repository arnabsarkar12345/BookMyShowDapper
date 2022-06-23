using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPIDapper.Controllers
{
    [Route("api/hall")]
    [ApiController]
    public class HallController : Controller
    {
        private readonly IHallService _hallService;
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet("{id}", Name = "HallByMovieId")]
        public async Task<IActionResult> GetHall(int id)
        {
            try
            {
                var hall = await _hallService.GetHall(id);
                return Ok(hall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("booking/{hallId}", Name = "HallByHallId")]
        public async Task<IActionResult> GetParticularHall(int hallId)
        {
            try
            {
                var hall = await _hallService.GetParticularHall(hallId);
                if (hall == null)
                    return NotFound();
                return Ok(hall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateHall(HallDTO hall)
        {
            try
            {
                var createdHall = await _hallService.CreateHall(hall);
                return CreatedAtRoute("HallById", new { id = createdHall.HallId}, createdHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(int id, HallDTO hall)
        {
            try
            {
                var dbHall = await _hallService.GetParticularHall(id);
                if (dbHall == null)
                    return NotFound();
                await _hallService.UpdateHall(id, hall);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
