using System;
using ACR2.Models.Resources;

namespace ACR2.Core.Models.Resources
{
    public class SaveWeekEntryResource
    {
         public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Mon { get; set; }
        public int Tue { get; set; } 
        public int Wed { get; set; }
        public int Thurs { get; set; }
        public int Fri { get; set; }
        public int WeekId { get; set; }
        public string Auth0Id { get; set; }
    }
}