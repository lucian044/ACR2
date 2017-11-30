using System.Collections.Generic;

namespace ACR2.Models.Resources
{
    public class WeekResource
    {
        public int Id { get; set; }
        public int Quarter { get; set; }
        public WeekNumberResource WeekNumber { get; set; }
        public List<WeekEntryResource> Entries { get; set; }
    }
}