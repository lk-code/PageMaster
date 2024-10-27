using lkcode.pagemaster.Contracts;

namespace lkcode.pagemaster;

/// <summary>
/// 
/// </summary>
/// <param name="pageSize">Maximum number of entries returned per page.</param>
/// <param name="totalCount">Total number of entries that exist for this query. Can be null if unknown.</param>
/// <param name="items">The items of this page.</param>
/// <typeparam name="T"></typeparam>
public class Page<T>(
    ulong currentPage,
    ulong pageSize,
    ulong totalCount,
    IEnumerable<T> items) : IPage<T>
{
    /// <inheritdoc />
    public ulong CurrentPage { get; } = currentPage;

    /// <inheritdoc />
    public ulong PageSize { get; } = pageSize;

    /// <inheritdoc />
    public ulong TotalCount { get; } = totalCount;

    /// <inheritdoc />
    public IEnumerable<T> Items { get; } = items;

    /// <inheritdoc />
    public ulong LastPage => TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;

    /// <inheritdoc />
    public ulong? NextPage => CurrentPage < LastPage ? CurrentPage + 1 : null;

    /// <inheritdoc />
    public ulong? PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : null;
}