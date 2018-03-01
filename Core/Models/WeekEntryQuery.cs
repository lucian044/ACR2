using ACR2.Extensions;

namespace ACR2.Core.Models
{
    public class WeekEntryQuery : IQueryObject
    {
        public int? Quarter { get; set; }
        public int? Week { get; set; }
        public int? Category { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Auth0Id { get; set; }
    }
}