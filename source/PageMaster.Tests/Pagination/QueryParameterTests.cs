using FluentAssertions;
using lkcode.pagemaster;
using lkcode.pagemaster.Filter;

namespace PageMaster.Tests.Pagination;

[TestClass]
public class QueryParameterTests
{
    [TestMethod]
    public void QueryParameter_WithoutSorting_Throws()
    {
        Sorting sorting = null!;

        Assert.ThrowsException<ArgumentNullException>(() => new QueryParameter(sorting));
    }

    [TestMethod]
    public void RemoveFilter_WithDifferentFilter_RemoveOnlyRequestedFilter()
    {
        var sorting = new Sorting("test", SortDirection.ASC);
        var queryParameter = new QueryParameter(sorting);

        queryParameter.AddFilter(new SearchValueFilter("user", "test-user", CompareOperator.EQUALS));

        queryParameter.RemoveFilter<SearchValueFilter>();

        queryParameter.HasFilter<SearchValueFilter>().Should().BeFalse();
    }

    [TestMethod]
    public void AddFilter_DuplicatedFilter_OnlyLatestFilter()
    {
        var sorting = new Sorting("test", SortDirection.ASC);
        var queryParameter = new QueryParameter(sorting);

        queryParameter.AddFilter(new SearchValueFilter("user", "test-user", CompareOperator.EQUALS));
        queryParameter.AddFilter(new SearchValueFilter("user", "another-test-user", CompareOperator.EQUALS));
        queryParameter.AddFilter(new SearchValueFilter("user", "correct-user", CompareOperator.EQUALS));

        queryParameter.HasFilter<SearchValueFilter>().Should().BeTrue();
        queryParameter.Count.Should().Be(1);

        var currentSearchFilter = queryParameter.GetFilter<SearchValueFilter>();
        currentSearchFilter.Should().NotBeNull();
        currentSearchFilter!.Value.Should().Be("correct-user");
        currentSearchFilter!.Key.Should().Be("user");
        currentSearchFilter!.Operator.Should().Be(CompareOperator.EQUALS);
    }
}
