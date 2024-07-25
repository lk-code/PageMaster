namespace lkcode.pagemaster.Filter;

/// <summary>
///
/// </summary>
public class SearchValueFilter : IFilter<string>
{
    private string _key;
    /// <summary>
    ///
    /// </summary>
    public string Key
    {
        get
        {
            return _key;
        }
        private set
        {
            _key = value;
        }
    }

    private string _value;
    /// <summary>
    ///
    /// </summary>
    public string Value
    {
        get
        {
            return _value;
        }
        private set
        {
            _value = value;
        }
    }

    private CompareOperator _operator;
    /// <summary>
    ///
    /// </summary>
    public CompareOperator Operator
    {
        get
        {
            return _operator;
        }
        private set
        {
            _operator = value;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="value"></param>
    public SearchValueFilter(string key,
        string value,
        CompareOperator compareOperator)
    {
        Key = key;
        Value = value;
        Operator = compareOperator;
    }

    public string GetKey() => Key;
    public CompareOperator GetComparisonOperator() => Operator;

    public string GetFilterValue() => Value;

    public string GetValue() => Value;

    public override string ToString()
    {
        return $"{nameof(SearchValueFilter)} => Value: '{Value}'";
    }
}
