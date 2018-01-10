namespace ACR2.Core.Models.Resources
{
    public class WeekEntryQueryResource
    {
        public int? Quarter { get; set; }
        public int? Week { get; set; }
        public int? Category { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}