using FluentAssertions;
using lkcode.pagemaster;

namespace PageMaster.Tests;

public class SortingExtensionsTests
{
    [Test]
    [TestCase("test:asc", new[] { "test"}, new[] { SortDirection.ASC })]
    [TestCase("test:Desc", new[] { "test"}, new[] { SortDirection.DESC })]
    [TestCase("test-alpha:asc,name:asc", new[] { "test-alpha", "name" }, new[] { SortDirection.ASC, SortDirection.ASC })]
    [TestCase("manufacturer:desc, name:asc", new[] { "manufacturer", "name" }, new[] { SortDirection.DESC, SortDirection.ASC })]
    [TestCase(" with spaces :desc, name:asc", new[] { "with spaces", "name" }, new[] { SortDirection.DESC, SortDirection.ASC })]
    public void QueryParameter_WithValid_Empty(string orderBy, string[] expectedSortKeys, SortDirection[] expectedSortDirections)
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
    
    [Test]
    public void QueryParameter_WithEmpty_Returns()
    {
        var orderBy = "";
        var sorting = orderBy.ToSorting()
            .ToList();

        sorting.Should().NotBeNull();
        sorting.Should().BeEmpty();
    }
}