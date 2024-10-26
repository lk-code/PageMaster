namespace lkcode.pagemaster.Contracts;

public interface IQueryParameter : IList<IFilter>
{
    /// <summary>
    /// the current page in the pagination.
    /// </summary>
    ulong CurrentPage { get; set; }
    /// <summary>
    /// specifies how many entries should be specified per page.
    /// </summary>
    ulong PageSize { get; set; }
    /// <summary>
    /// the configured sort.
    /// </summary>
    IEnumerable<Sorting> Sortings { get; set; }
    /// <summary>
    /// adds a filter to the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    void AddFilter(IFilter filterEntry);
    /// <summary>
    /// remove the given filter from the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    void RemoveFilter(IFilter filterEntry);
    /// <summary>
    /// remove the given filter from the list.
    /// </summary>
    /// <param name="filterEntry">the configured filter.</param>
    void RemoveFilter<T>();
    /// <summary>
    /// checks if the specified filter is present.
    /// </summary>
    /// <typeparam name="T">the type of the filter</typeparam>
    /// <returns></returns>
    bool HasFilter<T>();
    /// <summary>
    /// checks if the specified filter is present.
    /// </summary>
    /// <typeparam name="T">the type of the filter</typeparam>
    /// <returns></returns>
    T? GetFilter<T>();
}