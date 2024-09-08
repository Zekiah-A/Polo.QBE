namespace Polo.QBE;

/// <summary>
/// Represents a data definition item
/// </summary>
public interface IDataItem
{
}

public class SymbolDataItem : IDataItem
{
    public string Symbol { get; set; }
    public ulong? Offset { get; set; }

    public override string ToString()
    {
        if (Offset.HasValue)
        {
            return $"${Symbol} +{Offset.Value}";
        }
        return $"${Symbol}";
    }
}

public class StrDataItem : IDataItem
{
    public string String { get; set; }

    public override string ToString()
    {
        return $"\"{String}\"";
    }
}

public class ConstDataItem : IDataItem
{
    public ulong Constant { get; set; }

    public override string ToString()
    {
        return Constant.ToString();
    }
}