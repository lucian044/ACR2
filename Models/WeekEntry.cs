using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class WeekEntry
    {
        public int Id { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int Mon { get; set; }
        [Required]
        public int Tue { get; set; }
        [Required]
        public int Wed { get; set; }
        [Required]
        public int Thurs { get; set; }
        [Required]
        public int Fri { get; set; }
        public Week Week { get; set; }
        public int WeekId { get; set; }
    }
}