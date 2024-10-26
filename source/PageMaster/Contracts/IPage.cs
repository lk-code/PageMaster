namespace lkcode.pagemaster.Contracts;

public interface IPage<T>
{
    ulong CurrentPage { get; init; }
    ulong PerPage { get; init; }
    ulong? TotalEntries { get; init; }
    IEnumerable<T> Items { get; init; }
    ulong? LastPage { get; init; }
    ulong? NextPage { get; init; }
    ulong? PreviousPage { get; init; }
}