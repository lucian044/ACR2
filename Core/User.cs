using ACR2.Core.Models;

namespace ACR2.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Auth0Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}