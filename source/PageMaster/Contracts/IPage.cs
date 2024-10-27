namespace lkcode.pagemaster.Contracts;

public interface IPage<T>
{
    /// <summary>
    /// Current page number.
    /// </summary>
    ulong CurrentPage { get; }
    /// <summary>
    /// Maximum number of entries returned per page.
    /// </summary>
    ulong PageSize { get; }
    /// <summary>
    /// Total number of entries that exist for this query. Can be null if unknown.
    /// </summary>
    ulong TotalCount { get; }
    /// <summary>
    /// The items of this page.
    /// </summary>
    IEnumerable<T> Items { get; }
    /// <summary>
    /// Page number of the last page available. Can be null if the current page is the last one.
    /// </summary>
    ulong LastPage { get; }
    /// <summary>
    /// Page number of the next page. Can be null if the current page is the last one.
    /// </summary>
    ulong? NextPage { get; }
    /// <summary>
    /// Page number of the previous page. Can be null if the current page is the first one.
    /// </summary>
    ulong? PreviousPage { get; }
}