using FluentAssertions;
using lkcode.pagemaster;
using lkcode.pagemaster.Contracts;

namespace PageMaster.Tests;

public class PageTests
{
    [Test]
    public void Page_Init_Returns()
    {
        var lastPage = 9UL;
        var nextPage = 5UL;
        var currentPage = 4UL;
        var perPage = 10UL;
        var previousPage = 3UL;
        var totalEntries = 94UL;
        var items = new List<string> { "item1", "item2", "item3", "item4", "item5", "item6", "item7", "item8", "item9", "item10" };
        
        IPage<string> page = new Page<string>(
            lastPage,
            nextPage,
            currentPage,
            perPage,
            previousPage,
            totalEntries,
            items);
        
        page.LastPage.Should().Be(lastPage);
        page.NextPage.Should().Be(nextPage);
        page.CurrentPage.Should().Be(currentPage);
        page.PerPage.Should().Be(perPage);
        page.PreviousPage.Should().Be(previousPage);
        page.TotalEntries.Should().Be(totalEntries);
        page.Items.Should().BeEquivalentTo(items);
    }
}