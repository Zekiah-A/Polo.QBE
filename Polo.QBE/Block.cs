namespace Polo.QBE;

/// <summary>
/// Function block with a label
/// </summary>
public class Block
{
    public string Label { get; set; }
    public List<IStatement> Statements { get; set; }

    public Block(string label, List<IStatement>? statements = null)
    {
        Label = label;
        Statements = statements ?? new List<IStatement>();
    }

    /// <summary>
    /// Adds a new instruction to the block
    /// </summary>
    public void AddInstruction(IInstruction instruction)
    {
        Statements.Add(new VolatileStatement(instruction));
    }

    /// <summary>
    /// Adds a new instruction assigned to a temporary
    /// </summary>
    public void AssignInstruction(IValue tempValue, IType type, IInstruction instruction)
    {
        Statements.Add(new AssignStatement(tempValue, type.ToBase(), instruction));
    }

    /// <summary>
    /// Returns true if the block's last instruction is a jump
    /// </summary>
    public bool Jumps()
    {
        var lastStatement = Statements.Last();
        return lastStatement is VolatileStatement { Instruction: Ret or Jmp or Jnz };
    }

    public override string ToString()
    {
        var blockString = $"@{Label}\n";

        blockString += string.Join("\n", 
            Statements.Select(instr => $"\t{instr}")
        );

        return blockString;        
    }
}