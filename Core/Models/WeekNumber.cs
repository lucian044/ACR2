using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class WeekNumber
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
    }
}