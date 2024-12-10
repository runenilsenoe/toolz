// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace Tasks.Extensions;

public static class NumberExtensions
{
    // Positive Check
    public static bool IsPositive(this int number) => number > 0;
    public static bool IsPositive(this int? number) => number is > 0;
    public static bool IsPositive(this double number) => number > 0;
    public static bool IsPositive(this double? number) => number is > 0;

    // Negative Check
    public static bool IsNegative(this int number) => number < 0;
    public static bool IsNegative(this int? number) => number is < 0;
    public static bool IsNegative(this double number) => number < 0;
    public static bool IsNegative(this double? number) => number is < 0;

    // Zero Check
    public static bool IsZero(this int number) => number == 0;
    public static bool IsZero(this int? number) => number is 0;
    public static bool IsZero(this double number) => Math.Abs(number) < double.Epsilon;
    public static bool IsZero(this double? number) => number is not null && Math.Abs(number.Value) < double.Epsilon;

    // Range Check
    public static bool IsInRange(this int number, int min, int max) => number >= min && number <= max;
    public static bool IsInRange(this int? number, int min, int max) => number >= min && number <= max;
    public static bool IsInRange(this double number, double min, double max) => number >= min && number <= max;
    public static bool IsInRange(this double? number, double min, double max) => number >= min && number <= max;

    // Out of Range Check
    public static bool IsOutOfRange(this int number, int min, int max) => !number.IsInRange(min, max);
    public static bool IsOutOfRange(this int? number, int min, int max) => !number.IsInRange(min, max);
    public static bool IsOutOfRange(this double number, double min, double max) => !number.IsInRange(min, max);
    public static bool IsOutOfRange(this double? number, double min, double max) => !number.IsInRange(min, max);

    // Even Check
    public static bool IsEven(this int number) => number % 2 == 0;
    public static bool IsEven(this int? number) => number is not null && number % 2 == 0;

    // Odd Check
    public static bool IsOdd(this int number) => number % 2 != 0;
    public static bool IsOdd(this int? number) => number is not null && number % 2 != 0;

    // Whole Number Check
    public static bool IsWholeNumber(this double number) => Math.Abs(number % 1) < double.Epsilon;
    public static bool IsWholeNumber(this double? number) => number is not null && Math.Abs(number.Value % 1) < double.Epsilon;

    // Digit Count Validations
    /// <summary>
    /// Checks if the number has exactly the specified number of digits.
    /// </summary>
    public static bool HasExactDigits(this int number, int digitCount) => Math.Abs(number).ToString().Length == digitCount;

    public static bool HasExactDigits(this int? number, int digitCount) => number is not null && number.Value.HasExactDigits(digitCount);

    /// <summary>
    /// Checks if the number has at least the specified number of digits.
    /// </summary>
    public static bool HasMinimumDigits(this int number, int minDigits) => Math.Abs(number).ToString().Length >= minDigits;

    public static bool HasMinimumDigits(this int? number, int minDigits) => number is not null && number.Value.HasMinimumDigits(minDigits);

    /// <summary>
    /// Checks if the number has at most the specified number of digits.
    /// </summary>
    public static bool HasMaximumDigits(this int number, int maxDigits) => Math.Abs(number).ToString().Length <= maxDigits;

    public static bool HasMaximumDigits(this int? number, int maxDigits) => number is not null && number.Value.HasMaximumDigits(maxDigits);

    /// <summary>
    /// Checks if the number has digits within a specified range.
    /// </summary>
    public static bool HasDigitsInRange(this int number, int minDigits, int maxDigits)
    {
        var length = Math.Abs(number).ToString().Length;
        return length >= minDigits && length <= maxDigits;
    }

    public static bool HasDigitsInRange(this int? number, int minDigits, int maxDigits)
        => number is not null && number.Value.HasDigitsInRange(minDigits, maxDigits);
    
    public static int? RoundToClosest(this int? input, int rounder)
    {
        if (input is null)
            return null;
        
        var scaledNumber = input / rounder;
        var roundedScaledNumber = (int)Math.Round((double)scaledNumber);
        return roundedScaledNumber * rounder;
    }
}