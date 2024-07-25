namespace lkcode.pagemaster;

/// <summary>
/// contains the sorting configuration (column and direction)
/// </summary>
/// <param name="ColumnName">the column name to be sorted.</param>
/// <param name="Order">the sorting direction.</param>
public record Sorting(string ColumnName, SortDirection Order);