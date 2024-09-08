namespace Polo.QBE;

/// <summary>
/// Represents a QBE aggregate type definition
/// </summary>
public class TypeDef
{
    public string Name { get; set; }
    public ulong? Align { get; set; }
    public List<(IType Type, int Count)> Items { get; set; }

    public TypeDef(string name, List<(IType, int)> items, ulong? align = null)
    {
        Name = name;
        Items = items;
        Align = align;
    }

    public override string ToString()
    {
        var result = $"type :{Name} = ";

        if (Align.HasValue)
        {
            result += $"align {Align.Value} ";
        }

        result += "{ " +
            string.Join(", ", Items.Select(item => item.Count > 1 
                ? $"{item.Type} {item.Count}" 
                : $"{item.Type}")) +
            " }";

        return result;
    }
}
