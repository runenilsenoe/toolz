using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tasks.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty([NotNullWhen(false)]this string? input) => string.IsNullOrEmpty(input);
    public static bool IsNotNullOrEmpty([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);
    
    public static string RemoveSpecialCharacters(this string str) {
        StringBuilder sb = new StringBuilder();
        foreach (var character in 
                 str.Where(character => character 
                     is >= '0' and <= '9' 
                     or >= 'A' and <= 'Z' 
                     or >= 'a' and <= 'z' 
                     or '.' or '_'))
        {
            sb.Append(character);
        }
        return sb.ToString();
    }
}