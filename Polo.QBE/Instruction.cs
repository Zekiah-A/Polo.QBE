namespace Polo.QBE;

/// <summary>
/// Represents a QBE IL instruction
/// </summary>
public interface IInstruction
{
}

public interface IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }
}

/// <summary>
/// Adds values of two temporaries together
/// </summary>
public class Add : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Add(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"add {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Subtracts the second value from the first one
/// </summary>
public class Sub : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Sub(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"sub {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Multiplies values of two temporaries
/// </summary>
public class Mul : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Mul(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"mul {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Divides the first value by the second one
/// </summary>
public class Div : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Div(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"div {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Returns a remainder from division
/// </summary>
public class Rem : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Rem(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"rem {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Performs a comparion between values
/// </summary>
public class Cmp : IInstruction, IBinaryInstruction
{
    public TypeDef Type { get; }
    public CmpOp Comparison { get; }
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Cmp(TypeDef ty, CmpOp comparison, IValue lhs, IValue rhs)
    {
        Type = ty;
        Comparison = comparison;
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"c{Comparison}{Type} {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Performs a bitwise AND on values
/// </summary>
public class And : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public And(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"and {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Performs a bitwise OR on values
/// </summary>
public class Or : IInstruction, IBinaryInstruction
{
    public IValue Lhs { get; }
    public IValue Rhs { get; }

    public Or(IValue lhs, IValue rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public override string ToString()
    {
        return $"or {Lhs}, {Rhs}";
    }
}

/// <summary>
/// Copies either a temporary or a literal value
/// </summary>
public class Copy : IInstruction
{
    public IValue Value { get; }

    public Copy(IValue value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"copy {Value}";
    }
}

/// <summary>
/// Return from a function, optionally with a value
/// </summary>
public class Ret : IInstruction
{
    public IValue? Value { get; }

    public Ret(IValue? value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value != null ? $"ret {Value}" : "ret";
    }
}

/// <summary>
/// Jumps to first label if a value is nonzero or to the second one otherwise
/// </summary>
public class Jnz : IInstruction
{
    public IValue Val { get; }
    public string IfNonZero { get; }
    public string IfZero { get; }

    public Jnz(IValue val, string ifNonZero, string ifZero)
    {
        (Val, IfNonZero, IfZero) = (val, ifNonZero, ifZero);
    }

    public override string ToString()
    {
        return $"jnz {Val}, @{IfNonZero}, @{IfZero}";
    }
}

/// <summary>
/// Unconditionally jumps to a label
/// </summary>
public class Jmp : IInstruction
{
    public string Label { get; }

    public Jmp(string label)
    {
        Label = label;
    }

    public override string ToString()
    {
        return $"jmp @{Label}";
    }
}

public class Call : IInstruction
{
    public string Name { get; }
    public List<(Type, IValue)> Args { get; }

    public Call(string name, List<(Type, IValue)> args)
    {
        (Name, Args) = (name, args);
    }

    public override string ToString()
    {
        return $"call ${Name}({string.Join(", ", Args.Select(a => $"{a.Item1} {a.Item2}"))})";
    }
}

public class Alloc4 : IInstruction
{
    public uint Size { get; }

    public Alloc4(uint size)
    {
        Size = size;
    }

    public override string ToString()
    {
        return $"alloc4 {Size}";
    }
}

public class Alloc8 : IInstruction
{
    public ulong Size { get; }

    public Alloc8(ulong size)
    {
        Size = size;
    }

    public override string ToString()
    {
        return $"alloc8 {Size}";
    }
}

public class Alloc16 : IInstruction
{
    public ulong Size { get; }

    public Alloc16(ulong size)
    {
        Size = size;
    }

    public override string ToString()
    {
        return $"alloc16 {Size}";
    }
}

public class Store : IInstruction
{
    public Type Ty { get; }
    public IValue Dest { get; }
    public IValue IValue { get; }

    public Store(Type ty, IValue dest, IValue IValue)
    {
        (Ty, Dest, IValue) = (ty, dest, IValue);
    }

    public override string ToString()
    {
        return $"store{Ty} {IValue}, {Dest}";
    }
}

public class Load : IInstruction
{
    public TypeDef Type { get; }
    public IValue Src { get; }

    public Load(TypeDef type, IValue src)
    {
        Type = type;
        Src = src;
    }

    public override string ToString()
    {
        return $"load{Type} {Src}";
    }
}

public class Blit : IInstruction
{
    public IValue Src { get; }
    public IValue Dst { get; }
    public ulong N { get; }

    public Blit(IValue src, IValue dst, ulong n)
    {
        Src = src;
        Dst = dst;
        N = n;
    }

    public override string ToString()
    {
        return $"blit {Src}, {Dst}, {N}";
    }
}