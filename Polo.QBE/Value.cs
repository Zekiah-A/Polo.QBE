namespace Polo.QBE;

/// <summary>
/// Represents a QBE value that is accepted by instructions
/// </summary>
public interface IValue
{
    public string Name { get; set; }
}

public class TemporaryValue : IValue
{
    public string Name { get; set; }
    public override string ToString() => $"%{Name}";
}

public class GlobalValue : IValue
{
    public string Name { get; set; }
    public override string ToString() => $"${Name}";
}

public class ConstValue : IValue
{
    public string Name { get; set; }
    public override string ToString() => $"{Name}";
}
