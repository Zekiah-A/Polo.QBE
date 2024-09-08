using System.Text;

namespace Polo.QBE;

/// <summary>
/// Linkage of a function or data definition (e.g. section and
/// private/public status)
/// </summary>
public class Linkage
{
    /// <summary>
    /// Specifies whether the target is going to be accessible publicly
    /// </summary>
    public bool Exported { get; set; }

    /// <summary>
    /// Specifies target's section
    /// </summary>
    public string? Section { get; set; }

    /// <summary>
    /// Specifies target's section flags
    /// </summary>
    public string? SectionFlags { get; set; }

    /// <summary>
    /// Constructor for setting linkage parameters
    /// </summary>
    public Linkage(bool exported, string? section = null, string? sectionFlags = null)
    {
        Exported = exported;
        Section = section;
        SectionFlags = sectionFlags;
    }

    /// <summary>
    /// Returns the default configuration for private linkage
    /// </summary>
    public static Linkage Private() => new Linkage(false);

    /// <summary>
    /// Returns the configuration for private linkage with a provided section
    /// </summary>
    public static Linkage PrivateWithSection(string section) => new Linkage(false, section);

    /// <summary>
    /// Returns the default configuration for public linkage
    /// </summary>
    public static Linkage Public() => new Linkage(true);

    /// <summary>
    /// Returns the configuration for public linkage with a provided section
    /// </summary>
    public static Linkage PublicWithSection(string section) => new Linkage(true, section);
    
    public override string ToString()
    {
        var result = new StringBuilder();

        if (Exported)
        {
            result.Append("export ");
        }

        if (Section == null)
        {
            return result.ToString();
        }

        // TODO: escape section string if necessary
        result.Append($"section \"{Section}\"");

        if (SectionFlags != null)
        {
            result.Append($" \"{SectionFlags}\"");
        }

        result.Append(' ');

        return result.ToString();
    }
}