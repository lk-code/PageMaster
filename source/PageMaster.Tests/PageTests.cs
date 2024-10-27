using FluentAssertions;
using lkcode.pagemaster;
using lkcode.pagemaster.Contracts;

namespace PageMaster.Tests;

public class PageTests
{
    [Test]
    [TestCase(1UL, 4UL, 20UL, 5UL, 2UL, null)]
    [TestCase(2UL, 4UL, 20UL, 5UL, 3UL, 1UL)]
    [TestCase(4UL, 4UL, 20UL, 5UL, 5UL, 3UL)]
    [TestCase(5UL, 4UL, 20UL, 5UL, null, 4UL)]
    public void Page_Init_Returns(ulong currentPage, ulong pageSize, ulong totalCount,
        ulong expectedLastPage, ulong? expectedNextPage, ulong? expectedPreviousPage)
    {
        // generate List<string> with pageSize number items
        var items = new List<string>();
        for (ulong i = 0; i < pageSize; i++)
        {
            items.Add(i.ToString());
        }
        IPage<string> page = new Page<string>(
            currentPage,
            pageSize,
            totalCount,
            items);
        
        page.LastPage.Should().Be(expectedLastPage);
        page.NextPage.Should().Be(expectedNextPage);
        page.CurrentPage.Should().Be(currentPage);
        page.PageSize.Should().Be(pageSize);
        page.PreviousPage.Should().Be(expectedPreviousPage);
        page.TotalCount.Should().Be(totalCount);
        page.Items.Should().BeEquivalentTo(items);
    }
}