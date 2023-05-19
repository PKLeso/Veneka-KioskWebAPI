using KGKioskWebAPI.Interfaces;
using KGKioskWebAPI.Models;
using KGKioskWebAPI.Repository.Interface;

namespace KGKioskWebAPI.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetRoles()
        {
            return _roleRepository.GetRoles();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public bool RoleExists(int id)
        {
            return _roleRepository.RoleExists(id);
        }
    }

}
