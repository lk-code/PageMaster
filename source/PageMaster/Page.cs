namespace lkcode.pagemaster;

/// <summary>
/// contains a page with results and the current page settings.
/// </summary>
/// <param name="CurrentPage"> the current page number.</param>
/// <param name="ItemsPerPage">number of entries per page.</param>
/// <param name="TotalItemsCount">number of all entries.</param>
/// <param name="Items">the entries of the current page.</param>
/// <typeparam name="T"></typeparam>
public record Page<T>(ulong CurrentPage, ulong ItemsPerPage, ulong TotalItemsCount, IEnumerable<T> Items);