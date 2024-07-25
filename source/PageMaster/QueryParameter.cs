namespace lkcode.pagemaster;

/// <summary>
/// contains the query parameters with sorting and filtering.
/// </summary>
public class QueryParameter : List<IFilter>
{
    /// <summary>
    /// the current page in the pagination.
    /// </summary>
    public int CurrentPage { get; set; }
    /// <summary>
    /// specifies how many entries should be specified per page.
    /// </summary>
    public int ItemsPerPage { get; set; }
    /// <summary>
    /// the configured sort.
    /// </summary>
    public Sorting Sorting { get; set; }

    /// <summary>
    /// creates a new instance of <see cref="QueryParameter"/>.
    /// </summary>
    /// <param name="currentPage">the current page in the pagination.</param>
    /// <param name="itemsPerPage">specifies how many entries should be specified per page.</param>
    /// <param name="sorting">sorting config</param>
    public QueryParameter(Sorting sorting, int currentPage = 1, int itemsPerPage = 10)
    {
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        Sorting = sorting ?? throw new ArgumentNullException(nameof(sorting));
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