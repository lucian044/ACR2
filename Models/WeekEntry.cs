using System;
using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class WeekEntry
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
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
        [Required]
        public int WeekId { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}