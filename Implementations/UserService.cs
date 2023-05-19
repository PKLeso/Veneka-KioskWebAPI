using KGKioskWebAPI.Interfaces;
using KGKioskWebAPI.Models;
using KGKioskWebAPI.Repository.Interface;

namespace KGKioskWebAPI.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public bool AssignRoleToUser(int userId, int roleId)
        {
            return _userRepository.AssignRoleToUser(userId, roleId);
        }

        public bool RemoveRoleFromUser(int userId, int roleId)
        {
            return _userRepository.RemoveRoleFromUser(userId, roleId);
        }

        public bool ActivateUser(int id)
        {
            return _userRepository.ActivateUser(id);
        }

        public bool DeactivateUser(int id)
        {
            return _userRepository.DeactivateUser(id);
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            return _userRepository.UpdateUser(id, updatedUser);
        }

        public List<UserWithRoles> GetUsersWithRoles()
        {
            return _userRepository.GetUsersWithRoles();
        }

        public List<User> GetUsersByRole(int roleId)
        {
            return _userRepository.GetUsersByRole(roleId);
        }

        public List<Role> GetUserRoles(int userId)
        {
            return _userRepository.GetUserRoles(userId);
        }

        public bool UserExists(int id)
        {
            return _userRepository.UserExists(id);
        }

        public bool UpdateUserRole(int userId, int roleId)
        {
            if (!_roleRepository.RoleExists(roleId))
            {
                return false;
            }

            List<Role> userRoles = _userRepository.GetUserRoles(userId);
            if (userRoles.Any(r => r.Id == roleId))
            {
                return true; // Role is already assigned to the user
            }

            // Remove existing roles and assign the new role
            _userRepository.RemoveRolesFromUser(userId);
            _userRepository.AssignRoleToUser(userId, roleId);
            return true;
        }
    }

}
