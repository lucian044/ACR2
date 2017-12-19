using System.Collections.Generic;

namespace ACR2.Models.Resources
{
    public class WeekResource
    {
        public int Id { get; set; }
        public int Quarter { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public List<WeekEntryResource> Entries { get; set; }
    }
}