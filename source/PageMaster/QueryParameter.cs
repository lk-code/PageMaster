using lkcode.pagemaster.Contracts;

namespace lkcode.pagemaster;

/// <summary>
/// contains the query parameters with sorting and filtering.
/// </summary>
public class QueryParameter : List<IFilter>, IQueryParameter
{
    /// <inheritdoc />
    public ulong CurrentPage { get; set; }
    /// <inheritdoc />
    public ulong PageSize { get; set; }
    /// <inheritdoc />
    public IEnumerable<Sorting> Sortings { get; set; }

    /// <summary>
    /// creates a new instance of <see cref="QueryParameter"/>.
    /// </summary>
    /// <param name="currentPage">the current page in the pagination.</param>
    /// <param name="pageSizePage">specifies how many entries should be specified per page.</param>
    /// <param name="sortings">sortings config</param>
    public QueryParameter(IEnumerable<Sorting> sortings, ulong currentPage = 1, ulong pageSize = 10)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        Sortings = sortings ?? throw new ArgumentNullException(nameof(sortings));
    }

    /// <summary>
    /// creates a new instance of <see cref="QueryParameter"/>.
    /// </summary>
    /// <param name="currentPage">the current page in the pagination.</param>
    /// <param name="pageSizePage">specifies how many entries should be specified per page.</param>
    /// <param name="sorting">sorting config</param>
    public QueryParameter(Sorting sorting, ulong currentPage = 1, ulong pageSize = 10)
        : this(new List<Sorting>(), currentPage, pageSize)
    {
        if (sorting is not null)
        {
            Sortings.Append(sorting);
        }
    }

    /// <inheritdoc />
    public void AddFilter(IFilter filterEntry)
    {
        var existingFilter = this.SingleOrDefault(x => x.GetType() == filterEntry.GetType());
        if (existingFilter != null)
        {
            RemoveFilter(existingFilter);
        }

        base.Add(filterEntry);
    }

    /// <inheritdoc />
    public void RemoveFilter(IFilter filterEntry)
    {
        Remove(filterEntry);
    }

    /// <inheritdoc />
    public void RemoveFilter<T>()
    {
        var existingFilter = this.SingleOrDefault(x => x.GetType() == typeof(T));
        if (existingFilter != null)
        {
            RemoveFilter(existingFilter);
        }
    }

    /// <inheritdoc />
    public bool HasFilter<T>()
    {
        return (GetFilter<T>() != null);
    }

    /// <inheritdoc />
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