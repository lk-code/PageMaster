namespace lkcode.pagemaster;

/// <summary>
/// contains the sorting configuration (column and direction)
/// </summary>
/// <param name="FieldName">the field name to be sorted.</param>
/// <param name="Direction">the sorting direction.</param>
public record Sorting(string FieldName,
    SortDirection Direction);