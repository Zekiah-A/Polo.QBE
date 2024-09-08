namespace Polo.QBE;

/// <summary>
/// Represents a QBE data definition
/// </summary>
public class DataDef
{
    public Linkage Linkage { get; set; } 
    public string Name { get; set; }
    public ulong? Align { get; set; }
    public List<(IType, IDataItem)> Items;

    public DataDef(Linkage linkage, string name, ulong? align = null, List<(IType, IDataItem)>? items = null)
    {
        Linkage = linkage;
        Name = name;
        Align = align;
        Items = items ?? new List<(IType, IDataItem)>();
    }


    public override string ToString()
    {
        var result = $"{Linkage}data ${Name} = ";

        if (Align.HasValue)
        {
            result += $"align {Align.Value} ";
        }

        result += "{ " + string.Join(", ", Items.Select(item => $"{item.Item1} {item.Item2}")) + " }";

        return result;
    }
}