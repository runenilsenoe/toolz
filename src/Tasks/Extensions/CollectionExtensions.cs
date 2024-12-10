namespace Tasks.Extensions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class CollectionExtensions
{
    /// <summary>
    /// Filters out any null elements from the given enumerable and returns a new enumerable containing only non-null elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable. Must be a reference type.</typeparam>
    /// <param name="enumerable">The enumerable to filter</param>
    /// <returns>A new enumerable containing only non-null elements.</returns>
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> enumerable)  => enumerable.Where(e => e != null).Select(e => e!);
    
    /// <summary>
    /// Checks if the specified collection is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to check.</param>
    /// <returns>
    /// True if the collection is null or empty; otherwise, false.
    /// </returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
    {
        return collection is null || !collection.Any();
    }

    /// <summary>
    /// Checks if the specified collection is not null or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to check.</param>
    /// <returns>
    /// True if the collection is not null or empty; otherwise, false.
    /// </returns>
    public static bool IsNotNullOrEmpty<T>(this IEnumerable<T>? collection) => !IsNullOrEmpty(collection);
    
    public static T? TryGet<T>(this T[] input, int index) where T : class
    {
        var inRange = index <= input.Length - 1;
        if (!inRange)
            return null;
        var value = input.GetValue(index);
        return value as T;
    }
}