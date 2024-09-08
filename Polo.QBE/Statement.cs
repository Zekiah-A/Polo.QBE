namespace Polo.QBE;

/// <summary>
/// Represents an IR statement
/// </summary>
public interface IStatement
{
}

public class AssignStatement : IStatement
{
    public IValue TempValue { get; set; }
    public IType Type { get; set; }
    public IInstruction Instruction { get; set; }

    public AssignStatement(IValue tempValue, IType type, IInstruction instruction)
    {
        TempValue = tempValue;
        Type = type;
        Instruction = instruction;
    }

    public override string ToString()
    {
        if (TempValue is TemporaryValue)
        {
            return $"{TempValue} = {Type} {Instruction}";
        }
        
        throw new InvalidOperationException("Value must be of type TemporaryValue.");
    }
}

public class VolatileStatement : IStatement
{
    public IInstruction Instruction { get; set; }

    public VolatileStatement(IInstruction instruction)
    {
        Instruction = instruction;
    }

    public override string ToString()
    {
        return Instruction.ToString();
    }
}