namespace Tasks.Builders;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class MarkdownBuilderExtensions
{
    public enum HeadingLevel
    {
        H1 = 1,
        H2 = 2,
        H3 = 3,
        H4 = 4,
        H5 = 5,
        H6 = 6
    }
    
    /// <summary>
    /// Adds a heading with a specified level (e.g., H1, H2).
    /// </summary>
    public static string AddHeading(this string text, string heading, HeadingLevel level = HeadingLevel.H1) => AddHeading(text, heading, (int)level);
    
    /// <summary>
    /// Adds a heading with a specified level as integer (e.g., H1, H2).
    /// </summary>
    public static string AddHeading(this string text, string heading, int level = 1)
    {
        var prefix = new string('#', Math.Clamp(level, 1, 6)); // Markdown-style heading
        return text + $"{prefix} {heading}" + Environment.NewLine + Environment.NewLine;
    }
    
    /// <summary>
    /// Adds a blockquote to the text (e.g., Markdown style).
    /// </summary>
    public static string AddBlockquote(this string text, string quote)
        => text + Environment.NewLine + $"> {quote}" + Environment.NewLine;
    
    /// <summary>
    /// Adds a horizontal rule (e.g., Markdown style).
    /// </summary>
    public static string AddHorizontalRule(this string text)
        => text + Environment.NewLine + "---" + Environment.NewLine;
    
    /// <summary>
    /// Adds a key-value pair (e.g., for displaying properties or tables).
    /// </summary>
    public static string AddKeyValuePair(this string text, string key, string value)
        => text + $"{key}: {value}" + Environment.NewLine;
    
    /// <summary>
    /// Adds a numbered list item.
    /// </summary>
    public static string NewNumberedList(this string str, string[] listEntries)
    {
        foreach (var entry in listEntries.Select((x, i) => new { x, i })) 
            str += Environment.NewLine + $"{entry.i}. {entry.x}";
        return str;
    }

    /// <summary>
    /// Adds a code block with optional language (e.g., Markdown style).
    /// </summary>
    public static string AddCodeBlock(this string text, string code, string language = "") 
        => text + $"```{language}" + Environment.NewLine + code + Environment.NewLine + "```" + Environment.NewLine;
}