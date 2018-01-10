namespace ACR2.Core.Models.Resources
{
    public class WeekEntryQueryResource
    {
        public int? Quarter { get; set; }
        public int? Week { get; set; }
        public int? Category { get; set; }
        public string SoryBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}