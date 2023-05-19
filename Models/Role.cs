namespace KGKioskWebAPI.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
