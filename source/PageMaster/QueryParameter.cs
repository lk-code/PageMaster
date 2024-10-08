namespace lkcode.pagemaster;

/// <summary>
/// contains the query parameters with sorting and filtering.
/// </summary>
public class QueryParameter : List<IFilter>
{
    /// <summary>
    /// the current page in the pagination.
    /// </summary>
    public ulong CurrentPage { get; set; }
    /// <summary>
    /// specifies how many entries should be specified per page.
    /// </summary>
    public ulong ItemsPerPage { get; set; }
    /// <summary>
    /// the configured sort.
    /// </summary>
    public IEnumerable<Sorting> Sortings { get; set; }

    /// <summary>
    /// creates a new instance of <see cref="QueryParameter"/>.
    /// </summary>
    /// <param name="currentPage">the current page in the pagination.</param>
    /// <param name="itemsPerPage">specifies how many entries should be specified per page.</param>
    /// <param name="sortings">sortings config</param>
    public QueryParameter(IEnumerable<Sorting> sortings, ulong currentPage = 1, ulong itemsPerPage = 10)
    {
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        Sortings = sortings ?? throw new ArgumentNullException(nameof(sortings));
    }

    /// <summary>
    /// creates a new instance of <see cref="QueryParameter"/>.
    /// </summary>
    /// <param name="currentPage">the current page in the pagination.</param>
    /// <param name="itemsPerPage">specifies how many entries should be specified per page.</param>
    /// <param name="sorting">sorting config</param>
    public QueryParameter(Sorting sorting, ulong currentPage = 1, ulong itemsPerPage = 10)
        : this(new List<Sorting>(), currentPage, itemsPerPage)
    {
        if (sorting is not null)
        {
            Sortings.Append(sorting);
        }
    }

    /// <summary>
    /// adds a filter to the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    public void AddFilter(IFilter filterEntry)
    {
        var existingFilter = this.SingleOrDefault(x => x.GetType() == filterEntry.GetType());
        if (existingFilter != null)
        {
            RemoveFilter(existingFilter);
        }

        base.Add(filterEntry);
    }

    /// <summary>
    /// remove the given filter from the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    public void RemoveFilter(IFilter filterEntry)
    {
        Remove(filterEntry);
    }

    /// <summary>
    /// remove the given filter from the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    public void RemoveFilter<T>()
    {
        var existingFilter = this.SingleOrDefault(x => x.GetType() == typeof(T));
        if (existingFilter != null)
        {
            RemoveFilter(existingFilter);
        }
    }

    /// <summary>
    /// checks if the specified filter is present.
    /// </summary>
    /// <typeparam name="T">the type of the filter</typeparam>
    /// <returns></returns>
    public bool HasFilter<T>()
    {
        return (GetFilter<T>() != null);
    }

    /// <summary>
    /// checks if the specified filter is present.
    /// </summary>
    /// <typeparam name="T">the type of the filter</typeparam>
    /// <returns></returns>
    public T? GetFilter<T>()
    {
        var existingFilter = this.SingleOrDefault(x => x.GetType() == typeof(T));

        if (existingFilter == null)
        {
            return default;
        }

        return (T)existingFilter;
    }
}