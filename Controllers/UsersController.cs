using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cdn_assessment.Models;
using cdn_assessment.Services;

/*
    Explanation:
    GetAllUsers: Handles GET /api/users requests and returns the list of all users.
    GetUser: Handles GET /api/users/{id} requests to fetch a specific user by ID.
    CreateUser: Handles POST /api/users requests to create a new user.
    UpdateUser: Handles PUT /api/users/{id} requests to update an existing user.
    DeleteUser: Handles DELETE /api/users/{id} requests to delete a user by ID.
 */
namespace cdn_assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedUser = await _userService.UpdateUserAsync(user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
