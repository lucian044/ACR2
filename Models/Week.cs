using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACR2.Models
{
    public class Week
    {
        public int Id { get; set; }
        [Required]
        public int Quarter { get; set; }
        [Required]
        public int Number { get; set; }
        public int Year { get; set; }
        public List<WeekEntry> Entries { get; set; }

        public Week()
        {
            Entries = new List<WeekEntry>();
        }
    }
}