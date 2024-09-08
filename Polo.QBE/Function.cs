namespace Polo.QBE;

/// <summary>
/// QBE function
/// </summary>
public class Function
{
    /// <summary>
    /// Function's linkage
    /// </summary>
    public Linkage Linkage { get; set; }
    /// <summary>
    /// Function name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Function arguments
    /// </summary>
    public List<(IType, IValue)> Arguments { get; set; }
    /// <summary>
    /// Return type
    /// </summary>
    public IType? ReturnType { get; set; }
    /// <summary>
    /// Labelled blocks
    /// </summary>
    public List<Block> Blocks { get; set; }
    
    /// <summary>
    /// Constructor for creating a function
    /// </summary>
    public Function(Linkage linkage, string name, List<(IType, IValue)> arguments, IType? returnType = null)
    {
        Linkage = linkage;
        Name = name;
        Arguments = arguments;
        ReturnType = returnType;
        Blocks = new List<Block>();
    }

    /// <summary>
    /// Adds a new empty block with a specified label and returns a reference to it
    /// </summary>
    public Block AddBlock(string label)
    {
        var newBlock = new Block(label, new List<IStatement>());
        Blocks.Add(newBlock);
        return newBlock;
    }

    /// <summary>
    /// Returns a reference to the last block
    /// </summary>
    [Obsolete("Use Blocks.Last() or Blocks.LastOrDefault() instead.")]
    public Block LastBlock()
    {
        if (Blocks.Count == 0)
        {
            throw new InvalidOperationException("Function must have at least one block.");
        }

        return Blocks.Last();
    }

    /// <summary>
    /// Adds a new instruction to the last block
    /// </summary>
    public void AddInstr(IInstruction instruction)
    {
        if (Blocks.Count == 0)
        {
            throw new InvalidOperationException("Last block must be present.");
        }

        Blocks.Last().AddInstruction(instruction);
    }

    /// <summary>
    /// Adds a new instruction assigned to a temporary
    /// </summary>
    public void AssignInstr(IValue temp, IType type, IInstruction instruction)
    {
        if (Blocks.Count == 0)
        {
            throw new InvalidOperationException("Last block must be present.");
        }

        Blocks.Last().AssignInstruction(temp, type, instruction);
    }

    /// <summary>
    /// Converts the function to its string representation
    /// </summary>
    public override string ToString()
    {
        var result = $"{Linkage}function";
        
        if (ReturnType != null)
        {
            result += $" {ReturnType}";
        }

        result += $" ${Name}(";
        result += string.Join(", ", Arguments.Select(arg => $"{arg.Item1} {arg.Item2}"));
        result += ") {\n";

        foreach (var block in Blocks)
        {
            result += block + "\n";
        }

        result += "}";

        return result;
    }
}