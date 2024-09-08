namespace Polo.QBE;

public interface IType
{
    /// <summary>
    /// Returns a valid QBE-recognised C ABI type. Extended types are converted to the closest
    /// equivalent base types.
    /// </summary>
    public IType ToAbi();
    /// <summary>
    /// Returns the closest base type
    /// </summary>
    public IType ToBase();
    /// <summary>
    /// Returns byte size for values of the type
    /// </summary>
    public ulong Size();
    public string ToString();
}

// Base types

public class Word : IType
{
    public IType ToAbi() => this;
    public IType ToBase() => this;
    public ulong Size() => 4;
    public override string ToString() => "w";
}

public class Long : IType
{
    public IType ToAbi() => this;
    public IType ToBase() => this;
    public ulong Size() => 8;
    public override string ToString() => "l";
}

public class Single : IType
{
    public IType ToAbi() => this;
    public IType ToBase() => this;
    public ulong Size() => 4;
    public override string ToString() => "s";
}

public class Double : IType
{
    public IType ToAbi() => this;
    public IType ToBase() => this;
    public ulong Size() => 8;
    public override string ToString() => "d";
}

// Extended types

public class Byte : IType
{
    public IType ToAbi() => new Word();
    public IType ToBase() => new Word();
    public ulong Size() => 1;
    public override string ToString() => "b";
}

public class HalfWord : IType
{
    public IType ToAbi() => new Word();
    public IType ToBase() => new Word();
    public ulong Size() => 2;
    public override string ToString() => "h";
}

/// <summary>
/// Aggregate type with a specified name
/// </summary>
public class Aggregate : IType
{
    public TypeDef TypeDef { get; }

    public Aggregate(TypeDef typeDef) => TypeDef = typeDef;

    public IType ToAbi() => this;
    public IType ToBase() => new Long();
    
    public ulong Size()
    {
        ulong size = 0;
        foreach (var (item, repeat) in TypeDef.Items)
        {
            size += item.Size() * (ulong)repeat;
        }
        return size;
    }

    public override string ToString() => $":{TypeDef.Name}";
}

