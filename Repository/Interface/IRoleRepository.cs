using KGKioskWebAPI.Models;

namespace KGKioskWebAPI.Repository.Interface
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(int id);
        bool RoleExists(int id);
    }
}
