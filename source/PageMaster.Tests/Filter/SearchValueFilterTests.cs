using FluentAssertions;
using lkcode.pagemaster;
using lkcode.pagemaster.Filter;

namespace PageMaster.Tests.Filter;

public class SearchValueFilterTests
{
    [Test]
    public void ToString_WithTitle_DisplayTitle()
    {
        var filter = new SearchValueFilter("username", "specific-username", CompareOperator.EQUALS);

        var toStringValue = filter.ToString();

        toStringValue.Should().Be("SearchValueFilter => Value: 'specific-username'");
    }
}
