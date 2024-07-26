using FluentAssertions;
using lkcode.pagemaster;

namespace PageMaster.Tests;

[TestClass]
public class SortingExtensionsTests
{
    [DataRow("test-alpha:asc,name:asc", new[] { "test-alpha", "name" }, new[] { SortDirection.ASC, SortDirection.ASC })]
    [DataRow("manufacturer:desc, name:asc", new[] { "manufacturer", "name" }, new[] { SortDirection.DESC, SortDirection.ASC })]
    [DataRow(" with spaces :desc, name:asc", new[] { "with spaces", "name" }, new[] { SortDirection.DESC, SortDirection.ASC })]
    [TestMethod]
    public void QueryParameter_WithValid_Throws(string orderBy, string[] expectedSortKeys, SortDirection[] expectedSortDirections)
    {
        var sorting = orderBy.ToSorting()
            .ToList();

        sorting.Should().NotBeNull();
        sorting.Count.Should().Be(expectedSortKeys.Length);
        for(int i = 0; i < expectedSortKeys.Length; i++)
        {
            sorting[i].FieldName.Should().Be(expectedSortKeys[i]);
            sorting[i].Direction.Should().Be(expectedSortDirections[i]);
        }
    }
}