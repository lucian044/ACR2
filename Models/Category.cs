using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }
        [Required]
        public int CategoryNumber { get; set; }
    }
}