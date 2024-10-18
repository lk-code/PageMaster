namespace lkcode.pagemaster;

/// <summary>
/// 
/// </summary>
/// <param name="LastPage">Page number of the last page available. Can be null if the current page is the last one.</param>
/// <param name="NextPage">Page number of the next page. Can be null if the current page is the last one.</param>
/// <param name="CurrentPage">Current page number.</param>
/// <param name="PerPage">Maximum number of entries returned per page.</param>
/// <param name="PreviousPage">Page number of the previous page. Can be null if the current page is the first one.</param>
/// <param name="TotalEntries">Total number of entries that exist for this query. Can be null if unknown.</param>
/// <param name="Items">The items of this page.</param>
/// <typeparam name="T"></typeparam>
public record Page<T>(ulong? LastPage,
    ulong? NextPage,
    ulong CurrentPage,
    ulong PerPage,
    ulong? PreviousPage,
    ulong? TotalEntries,
    IEnumerable<T> Items);