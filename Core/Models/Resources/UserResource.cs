using ACR2.Core.Models.Resources;

namespace ACR2.Models.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string Auth0Id { get; set; }
        public int SchoolId { get; set; }
    }
}