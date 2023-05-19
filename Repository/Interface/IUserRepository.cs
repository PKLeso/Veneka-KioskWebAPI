using KGKioskWebAPI.Models;

namespace KGKioskWebAPI.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        bool DeleteUser(int id);
        bool AssignRoleToUser(int userId, int roleId);
        bool RemoveRoleFromUser(int userId, int roleId);
        bool ActivateUser(int id);
        bool DeactivateUser(int id);
        bool UpdateUser(int id, User updatedUser);
        List<UserWithRoles> GetUsersWithRoles();
        List<User> GetUsersByRole(int roleId);
        List<Role> GetUserRoles(int userId);
        bool UserExists(int id);
        void RemoveRolesFromUser(int userId);
    }
}
