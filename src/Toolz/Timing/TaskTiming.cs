using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Tasks.Timing;

public static class TaskTiming
{
    public static async Task LogTimingToConsole(this Task task, ILogger? logger = null,  Action<TimeSpan>? elapsedAction = null, [CallerMemberName] string callerName = "", string? callerMemberName = null)
    {
        var stopwatch = Stopwatch.StartNew();
        await task;
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        elapsedAction?.Invoke(elapsed);

        callerMemberName = string.IsNullOrEmpty(callerMemberName)
            ? "" : $"- {callerMemberName}";
        
        var message = $"Calling method: {callerName}" + callerMemberName + $" used {elapsed.TotalMilliseconds} to execute";
        if (logger != null)
            logger.LogInformation(message);
        else
            Console.WriteLine(message);
    }
    public static async Task<T> LogTimingToConsole<T>(this Task<T> task, ILogger? logger = null,  Action<TimeSpan>? elapsedAction = null, [CallerMemberName] string callerName = "", string? callerMemberName = null)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = await task;
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        elapsedAction?.Invoke(elapsed);

        callerMemberName = string.IsNullOrEmpty(callerMemberName)
            ? "" : $"- {callerMemberName}";
        
        var message = $"Calling method: {callerName}" + callerMemberName + $" used {elapsed.TotalMilliseconds} to execute";
        if (logger != null)
            logger.LogInformation(message);
        else
            Console.WriteLine(message);
        return result;
    }

    /// <summary>
    /// Measures the elapsed time of a task execution.
    /// </summary>
    /// <typeparam name="T">The return type of the task.</typeparam>
    /// <param name="task">The task to measure.</param>
    /// <param name="elapsedAction">An optional action that takes the elapsed time as input.</param>
    /// <returns>The result of the task along with the time taken.</returns>
    public static async Task<(T result, TimeSpan elapsed)> WithTiming<T>(this Task<T> task, Action<TimeSpan>? elapsedAction = null)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = await task;
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        elapsedAction?.Invoke(elapsed); // Optionally execute an action with the elapsed time

        return (result, elapsed);
    }
    
    /// <summary>
    /// Measures the elapsed time of a task execution without a return value.
    /// </summary>
    /// <param name="task">The task to measure.</param>
    /// <param name="elapsedAction">An optional action that takes the elapsed time as input.</param>
    /// <returns>The time taken for the task to complete.</returns>
    public static async Task<TimeSpan> WithTiming(this Task task, Action<TimeSpan>? elapsedAction = null)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await task;
        }
        finally
        {
            stopwatch.Stop();
            elapsedAction?.Invoke(stopwatch.Elapsed);
        }
        return stopwatch.Elapsed;
    }
    /// <summary>
    /// Measures the elapsed time of a synchronous function execution.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    /// <param name="func">The function to measure.</param>
    /// <param name="elapsedAction">An optional action to handle the elapsed time.</param>
    /// <returns>A tuple containing the result of the function and the elapsed time.</returns>
    public static (T result, TimeSpan elapsed) WithTiming<T>(this Func<T> func, Action<TimeSpan> elapsedAction)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = func();
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        elapsedAction.Invoke(elapsed);

        return (result, elapsed);
    }

    /// <summary>
    /// Measures the elapsed time of an action (void function) execution.
    /// </summary>
    /// <param name="action">The action to measure.</param>
    /// <param name="elapsedAction">An optional action to handle the elapsed time.</param>
    /// <returns>The elapsed time of the action.</returns>
    public static TimeSpan WithTiming(this Action action, Action<TimeSpan>? elapsedAction = null)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        elapsedAction?.Invoke(elapsed);

        return elapsed;
    }
    
    public static (T result, TimeSpan elapsed) WithTiming<T>(this Func<T> func)
    {
        var stopwatch = Stopwatch.StartNew();
        T result = func();
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        return (result, elapsed);
    }
    
    public static async Task<bool> RunWithTimeout(this Task task, TimeSpan timeout)
    {
        return await Task.WhenAny(task, Task.Delay(timeout)) == task;
    }
}