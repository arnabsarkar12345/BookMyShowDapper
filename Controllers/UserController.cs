using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPIDapper.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var users = await _userService.GetUser();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetParticularUser(int id)
        {
            try
            {
                var user = await _userService.GetParticularUser(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user);
                return CreatedAtRoute("UserById", new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO user)
        {
            try
            {
                var dbUser = await _userService.GetParticularUser(id);
                if (dbUser == null)
                    return NotFound();
                await _userService.UpdateUser(id, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var dbUser = await _userService.GetParticularUser(id);
                if (dbUser == null)
                    return NotFound();
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
