using System.Text.RegularExpressions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace Tasks.Extensions;

public static partial class SpecificStringValidations
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex MyRegex();
    public static bool IsValidEmail(this string email) => MyRegex().IsMatch(email);
}