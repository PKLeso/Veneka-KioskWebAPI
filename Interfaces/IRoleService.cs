using KGKioskWebAPI.Models;

namespace KGKioskWebAPI.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetRoles();
        Role GetRoleById(int id);
        bool RoleExists(int id);
    }
}
