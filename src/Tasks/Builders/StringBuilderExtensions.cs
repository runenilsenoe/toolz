using System.Text;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace Tasks.Builders;

/// <summary>
/// Extensions to build slightly formatted basic string texts
/// </summary>
public static class StringBuilderExtensions
{
    public static string Title(string text) => text + Environment.NewLine;
    public static string AddParagraph(this string text) => text + Environment.NewLine + Environment.NewLine;
    public static string AddSpacer(this string text) => text + Environment.NewLine;
    public static string AddTextLine(this string str, string text) => str + Environment.NewLine + text;
    public static string NewLine(this string str) => str + Environment.NewLine;
    public static string NewListLine(this string str, string input, string listOperator) 
        => str + Environment.NewLine + $"    {listOperator} " + input;
    public static string NewListPoint(this string str, string input) => str.NewListLine(input, "*");
    public static string NewListDash(this string str, string input) => str.NewListLine(input, "-");
    
    
    /// <summary>
    /// Wraps the text to a specified line width.
    /// </summary>
    public static string WrapText(this string text, int lineWidth)
    {
        var words = text.Split(' ');
        var wrappedText = new StringBuilder();
        var line = new StringBuilder();

        foreach (var word in words)
        {
            if (line.Length + word.Length + 1 > lineWidth)
            {
                wrappedText.AppendLine(line.ToString());
                line.Clear();
            }
            if (line.Length > 0) line.Append(" ");
            line.Append(word);
        }
        if (line.Length > 0)
            wrappedText.AppendLine(line.ToString());

        return wrappedText.ToString();
    }
}