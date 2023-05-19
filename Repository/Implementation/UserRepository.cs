using KGKioskWebAPI.Data;
using KGKioskWebAPI.Models;
using KGKioskWebAPI.Repository.Interface;

namespace KGKioskWebAPI.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private List<Role> _roles;
        private List<UserRole> _userRoles;
        private readonly KioskDbContext _context;

        public UserRepository(KioskDbContext context)
        {
            _users = new List<User>();
            _roles = new List<Role>();
            _userRoles = new List<UserRole>();
            _context = context;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            user.Id = GenerateUserId();
            _context.Users.Add(user);
            return user;
        }

        public bool DeleteUser(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                RemoveUserRoles(id);
                return true;
            }
            return false;
        }

        public bool AssignRoleToUser(int userId, int roleId)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            Role role = _context.Roles.FirstOrDefault(r => r.Id == roleId);

            if (user != null && role != null)
            {
                if (!IsUserRoleExists(userId, roleId))
                {
                    _context.UserRoles.Add(new UserRole(userId, roleId));
                }
                return true;
            }
            return false;
        }

        public bool RemoveRoleFromUser(int userId, int roleId)
        {
            UserRole userRole = _context.UserRoles.FirstOrDefault(ur => ur.Id == userId && ur.RoleId == roleId);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                return true;
            }
            return false;
        }

        public bool ActivateUser(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsActive = true;
                return true;
            }
            return false;
        }

        public bool DeactivateUser(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsActive = false;
                return true;
            }
            return false;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                return true;
            }
            return false;
        }

        public List<UserWithRoles> GetUsersWithRoles()
        {
            List<UserWithRoles> usersWithRoles = new List<UserWithRoles>();
            foreach (User user in _users)
            {
                List<Role> roles = GetUserRoles(user.Id);
                usersWithRoles.Add(new UserWithRoles(user.Id, user.FirstName, user.LastName, user.Email, roles));
            }
            return usersWithRoles;
        }

        public List<User> GetUsersByRole(int roleId)
        {
            List<User> users = new List<User>();
            foreach (UserRole userRole in _userRoles.Where(ur => ur.RoleId == roleId))
            {
                User user = _context.Users.FirstOrDefault(u => u.Id == userRole.Id);
                if (user != null)
                {
                    _context.Users.Add(user);
                }
            }
            return users;
        }

        public List<Role> GetUserRoles(int userId)
        {
            List<Role> roles = new List<Role>();
            foreach (UserRole userRole in _context.UserRoles.Where(ur => ur.Id == userId))
            {
                Role role = _context.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);
                if (role != null)
                {
                    roles.Add(role);
                }
            }
            return roles;
        }

        private int GenerateUserId()
        {
            int maxId = _users.Any() ? _users.Max(u => u.Id) : 0;
            return maxId + 1;
        }

        private void RemoveUserRoles(int userId)
        {
            List<UserRole> userRolesToRemove = _userRoles.Where(ur => ur.Id == userId).ToList();
            foreach (UserRole userRole in userRolesToRemove)
            {
                _userRoles.Remove(userRole);
            }
        }

        private bool IsUserRoleExists(int userId, int roleId)
        {
            return _userRoles.Any(ur => ur.Id == userId && ur.RoleId == roleId);
        }

        public bool UserExists(int id)
        {
            return _users.Any(u => u.Id == id);
        }

        public void RemoveRolesFromUser(int userId)
        {
            List<UserRole> userRolesToRemove = _userRoles.Where(ur => ur.Id == userId).ToList();
            foreach (UserRole userRole in userRolesToRemove)
            {
                _userRoles.Remove(userRole);
            }
        }
    }
}
