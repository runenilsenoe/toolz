using System.ComponentModel;

namespace Tasks.Extensions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class EnumExtensions
{
    /// <summary>
    /// Gets the display name (Description) of the enum value.
    /// </summary>
    public static string GetEnumDescription(this Enum e)
    {
        var descriptionAttribute = e.GetType().GetMember(e.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0] 
            as DescriptionAttribute;

        return descriptionAttribute?.Description ?? "";
    }
    
    /// <summary>
    /// Searches for an enum value based on its display name, with optional substring and case-insensitive matching.
    /// </summary>
    /// <param name="searchTerm">The display name or a substring to search for.</param>
    /// <param name="ignoreCase">If true, performs case-insensitive comparison. Default is true.</param>
    /// <param name="allowSubstringMatch">If true, allows matching against substrings of the display name. Default is false.</param>
    /// <returns>The matching enum value, or null if no match is found.</returns>
    public static TEnum? SearchByDisplayName<TEnum>(string searchTerm, bool ignoreCase = true, bool allowSubstringMatch = false) where TEnum : struct, Enum
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

        foreach (var value in Enum.GetValues<TEnum>())
        {
            var displayName = value.GetEnumDescription();
            if (allowSubstringMatch)
            {
                if (displayName.Contains(searchTerm, comparison))
                    return value;
            }
            else
            {
                if (string.Equals(displayName, searchTerm, comparison))
                    return value;
            }
        }
        return null;
    }
    
    /// <summary>
    /// Needs to be called with a random enum instance value.
    /// As an example: MyEnum.None.RandomValueExceptZero()
    /// </summary>
    /// <param name="enumInstance"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static T RandomValueExceptZero<T>(this T enumInstance) where T : struct, Enum
    {
        var values = Enum.GetValues(enumInstance.GetType()).Cast<T>()
            .Where(e => Convert.ToInt64(e) != 0)
            .ToArray();

        if (values.Length == 0)
            throw new InvalidOperationException("Enum has no non-zero values.");

        return values[new Random().Next(values.Length)];
    }
}