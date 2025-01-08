using Tasks.Models.Enums;

namespace Tasks.Extensions;

public static class TimespanExtensions
{
    public static string StringWithUnit(this TimeSpan timespan, TimeSpanFormat format) => format switch
    {
        TimeSpanFormat.Milliseconds => $"{timespan.TotalMilliseconds:F0} ms",
        TimeSpanFormat.Seconds => $"{timespan.TotalSeconds:F0} sec",
        TimeSpanFormat.Minutes => $"{timespan.TotalMinutes:F0} min",
        TimeSpanFormat.Hours => $"{timespan.TotalHours:F0} hrs",
        TimeSpanFormat.Days => $"{timespan.TotalDays:F0} days",
        TimeSpanFormat.Weeks => $"{timespan.TotalDays / 7:F1} weeks",
        TimeSpanFormat.Months => $"{timespan.TotalDays / 30:F1} months",
        TimeSpanFormat.Years => $"{timespan.TotalDays / 365:F1} years",
        _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
    };
    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in milliseconds, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in milliseconds, e.g., "500 ms".</returns>
    public static string TotalMillisecondsStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Milliseconds);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in seconds, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in seconds, e.g., "30 sec".</returns>
    public static string TotalSecondsStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Seconds);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in minutes, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in minutes, e.g., "15 min".</returns>
    public static string TotalMinutesStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Minutes);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in hours, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in hours, e.g., "2 hrs".</returns>
    public static string TotalHoursStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Hours);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in days, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in days, e.g., "3 days".</returns>
    public static string TotalDaysStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Days);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in weeks, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in weeks, e.g., "1.5 weeks".</returns>
    public static string TotalWeeksStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Weeks);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in months, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in months, e.g., "2.3 months".</returns>
    public static string TotalMonthsStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Months);

    /// <summary>
    /// Converts the given <see cref="TimeSpan"/> to a string representation in years, including the unit.
    /// </summary>
    /// <param name="timespan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>A string representation of the time span in years, e.g., "1.2 years".</returns>
    public static string TotalYearsStringWithUnit(this TimeSpan timespan) => timespan.StringWithUnit(TimeSpanFormat.Years);
}