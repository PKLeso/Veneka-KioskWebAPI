using KGKioskWebAPI.Implementations;
using KGKioskWebAPI.Interfaces;
using KGKioskWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KGKioskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/users")]
        public IActionResult GetUsers()
        {
            // Retrieve and return a list of available users
            List<User> users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IActionResult GetUserById(int id)
        {
            // Retrieve the user by Id
            User user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound(); // User not found
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult CreateUser([FromBody] User user)
        {
            // Validate user data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create the user
            User createdUser = _userService.CreateUser(user);

            return CreatedAtAction("GetUserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Delete the user
            bool deleted = _userService.DeleteUser(id);

            if (!deleted)
            {
                return NotFound(); // User not found
            }

            return NoContent();
        }

        [HttpPut]
        [Route("api/users/{id}/activate")]
        public IActionResult ActivateUser(int id)
        {
            // Activate the user
            bool activated = _userService.ActivateUser(id);

            if (!activated)
            {
                return NotFound(); // User not found
            }

            return NoContent();
        }

        [HttpPut]
        [Route("api/users/{id}/deactivate")]
        public IActionResult DeactivateUser(int id)
        {
            // De-activate the user
            bool deactivated = _userService.DeactivateUser(id);

            if (!deactivated)
            {
                return NotFound(); // User not found
            }

            return NoContent();
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            // Validate user data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the user details
            bool updated = _userService.UpdateUser(id, user);

            if (!updated)
            {
                return NotFound(); // User not found
            }

            return NoContent();
        }


    }
}
