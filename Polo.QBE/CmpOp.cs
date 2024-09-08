namespace Polo.QBE;

/// <summary>
/// Represents a QBE comparision operation.
/// TODO: Consider adding friendly names with identical enum values, such as SignedLessThan for Slt
/// </summary>
public enum CmpOp
{
    /// <summary>
    /// Returns 1 if first value is less than second, respecting signedness. Mnemonic: `slt`
    /// </summary>
    Slt = 0,
    /// <summary>
    /// Returns 1 if first value is less than or equal to second, respecting signedness. Mnemonic: `sle`
    /// </summary>
    Sle,
    /// <summary>
    /// Returns 1 if first value is greater than second, respecting signedness. Mnemonic: `sgt`
    /// </summary>
    Sgt,
    /// <summary>
    /// Returns 1 if first value is greater than or equal to second, respecting signedness. Mnemonic: `sge`
    /// </summary>
    Sge,
    /// <summary>
    /// Returns 1 if values are equal. Mnemonic: `eq`
    /// </summary>
    Eq,
    /// <summary>
    /// Returns 1 if values are not equal. Mnemonic: `ne`
    /// </summary>
    Ne
}