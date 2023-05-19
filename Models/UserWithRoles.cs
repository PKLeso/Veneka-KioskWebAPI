namespace KGKioskWebAPI.Models
{
    public class UserWithRoles
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }

        public UserWithRoles(int id, string firstName, string lastName, string email, List<Role> roles)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Roles = roles;
        }
    }
}
