namespace KGKioskWebAPI.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public UserRole(int userId, int roleId)
        {
            Id = userId;
            RoleId = roleId;
        }
    }
}
