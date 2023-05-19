using KGKioskWebAPI.Data;
using KGKioskWebAPI.Models;
using KGKioskWebAPI.Repository.Interface;

namespace KGKioskWebAPI.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private List<Role> _roles;
        private readonly KioskDbContext _context;

        public RoleRepository(KioskDbContext context)
        {
            _roles = new List<Role>();
            _context = context;
        }

        public List<Role> GetRoles()
        {
            var roles = _context.Roles.ToList();
            return roles;
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public bool RoleExists(int id)
        {
            return _context.Roles.Any(r => r.Id == id);
        }
    }

}
