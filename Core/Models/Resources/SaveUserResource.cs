namespace ACR2.Core.Models.Resources
{
    public class SaveUserResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Auth0Id { get; set; }
        public int SchoolId { get; set; }
    }
}