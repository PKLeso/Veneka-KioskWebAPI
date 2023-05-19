using KGKioskWebAPI.Models;
using KGKioskWebAPI.Repository.Interface;

namespace KGKioskWebAPI.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private List<Role> _roles;

        public RoleRepository()
        {
            _roles = new List<Role>();
        }

        public List<Role> GetRoles()
        {
            return _roles;
        }

        public Role GetRoleById(int id)
        {
            return _roles.FirstOrDefault(r => r.RoleId == id);
        }

        public bool RoleExists(int id)
        {
            return _roles.Any(r => r.RoleId == id);
        }
    }

}
