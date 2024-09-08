namespace Polo.QBE;

public class Module
{
    public List<Function> Functions { get; set; }
    public List<TypeDef> Types { get; set; }
    public List<DataDef> Data { get; set; }

    public Module(List<Function>? functions = null, List<TypeDef>? typeDefs = null, List<DataDef>? dataDefs = null)
    {
        Functions = functions ?? new List<Function>();
        Types = typeDefs ?? new List<TypeDef>();
        Data = dataDefs ?? new List<DataDef>();
    }

    /// <summary>
    /// Adds a function to the module and returns a reference to it for later modification.
    /// </summary>
    public Function AddFunction(Function func)
    {
        Functions.Add(func);
        return Functions.Last();
    }

    /// <summary>
    /// Adds a type definition to the module and returns a reference to it for later modification.
    /// </summary>
    public TypeDef AddType(TypeDef def)
    {
        Types.Add(def);
        return Types.Last();
    }

    /// <summary>
    /// Adds a data definition to the module and returns a reference to it for later modification.
    /// </summary>
    public DataDef AddData(DataDef data)
    {
        Data.Add(data);
        return Data.Last();
    }

    /// <summary>
    /// Overrides the ToString method to display the module's content.
    /// </summary>
    public override string ToString()
    {
        var result = new System.Text.StringBuilder();

        foreach (var func in Functions)
        {
            result.AppendLine(func.ToString());
        }

        foreach (var typeDef in Types)
        {
            result.AppendLine(typeDef.ToString());
        }

        foreach (var dataDef in Data)
        {
            result.AppendLine(dataDef.ToString());
        }

        return result.ToString();
    }
}