using System.Collections.Generic;

namespace ACR2.Models
{
    public class Week
    {
        public int Id { get; set; }
        public int Quarter { get; set; }
        public WeekNumber WeekNumber { get; set; }
        public List<WeekEntry> Entries { get; set; }
    }
}