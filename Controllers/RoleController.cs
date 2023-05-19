
using KGKioskWebAPI.Implementations;
using KGKioskWebAPI.Interfaces;
using KGKioskWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KGKioskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }


        [HttpGet]
        [Route("api/roles")]
        public IActionResult GetRoles()
        {
            // Retrieve and return a list of available roles
            List<Role> roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpPost]
        [Route("api/users/{userId}/roles/{roleId}")]
        public IActionResult AssignRoleToUser(int userId, int roleId)
        {
            // Check if user and role exist
            if (!_userService.UserExists(userId) || !_roleService.RoleExists(roleId))
            {
                return NotFound();
            }

            // Assign the role to the user
            _userService.AssignRoleToUser(userId, roleId);

            return NoContent();
        }

        [HttpDelete]
        [Route("api/users/{userId}/roles/{roleId}")]
        public IActionResult RemoveRoleFromUser(int userId, int roleId)
        {
            // Check if user and role exist
            if (!_userService.UserExists(userId) || !_roleService.RoleExists(roleId))
            {
                return NotFound();
            }

            // Remove the role from the user
            _userService.RemoveRoleFromUser(userId, roleId);

            return NoContent();
        }

        [HttpGet]
        [Route("api/users/withRoles")]
        public IActionResult GetUsersWithRoles()
        {
            // Retrieve a list of users with their assigned roles
            List<UserWithRoles> usersWithRoles = _userService.GetUsersWithRoles();
            return Ok(usersWithRoles);
        }

        [HttpGet]
        [Route("api/roles/{roleId}/users")]
        public IActionResult GetUsersByRole(int roleId)
        {
            // Retrieve a list of users based on the specified role
            List<User> users = _userService.GetUsersByRole(roleId);
            return Ok(users);
        }

        [HttpGet]
        [Route("api/users/{userId}/roles")]
        public IActionResult GetUserRoles(int userId)
        {
            // Retrieve a list of roles assigned to the user
            List<Role> roles = _userService.GetUserRoles(userId);

            if (roles == null)
            {
                return NotFound(); // User not found
            }

            return Ok(roles);
        }

        [HttpPut]
        [Route("api/users/{userId}/roles/{roleId}")]
        public IActionResult UpdateUserRole(int userId, int roleId)
        {
            // Check if user and role exist
            if (!_userService.UserExists(userId) || !_roleService.RoleExists(roleId))
            {
                return NotFound();
            }

            // Update the user's role
            bool updated = _userService.UpdateUserRole(userId, roleId);

            if (!updated)
            {
                return NotFound(); // User or role not found
            }

            return NoContent();
        }

    }
}
