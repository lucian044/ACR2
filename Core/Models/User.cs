using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Auth0Id { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}