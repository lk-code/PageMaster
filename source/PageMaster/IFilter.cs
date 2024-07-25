namespace lkcode.pagemaster;

public interface IFilter
{
    public string GetKey();
    public CompareOperator GetComparisonOperator();
    public string GetValue();
}

public interface IFilter<T> : IFilter
{
    public T GetFilterValue();
}
