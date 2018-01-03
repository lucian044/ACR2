using System;

namespace ACR2.Models.Resources
{
    public class WeekEntryResource
    {
        public int Id { get; set; }
        public CategoryResource Category { get; set; }
        public int Mon { get; set; }
        public int Tue { get; set; }
        public int Wed { get; set; }
        public int Thurs { get; set; }
        public int Fri { get; set; }
        public WeekResource Week { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}