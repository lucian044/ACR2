namespace ACR2.Extensions
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
    }
}