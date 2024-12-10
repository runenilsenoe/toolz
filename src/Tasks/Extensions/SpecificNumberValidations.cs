namespace Tasks.Extensions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class SpecificNumberValidations
{
    public static bool IsValidCreditCard(this string number)
    {
        var sum = 0;
        var alternate = false;

        for (var i = number.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(number[i])) return false;

            var digit = number[i] - '0';
            if (alternate)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }
            sum += digit;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }
}