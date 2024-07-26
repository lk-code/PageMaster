namespace lkcode.pagemaster;

public static class SortingExtensions
{
    public static IEnumerable<Sorting> ToSorting(this string orderBy)
    {
        if (string.IsNullOrEmpty(orderBy.Trim()))
        {
            return new List<Sorting>();
        }
        
        string[] orderByValues = orderBy
            .Trim()
            .Split(",");

        return orderByValues
            .Select(x =>
            {
                string[] orderByValue = x.Split(":");

                string sortKey = orderByValue[0].Trim();
                SortDirection sortDirection = orderByValue[1].Trim().ToLowerInvariant() switch
                {
                    "asc" => SortDirection.ASC,
                    "desc" => SortDirection.DESC,
                    _ => throw new ArgumentException("Invalid sort direction")
                };

                return new Sorting(sortKey, sortDirection);
            });
    }
}