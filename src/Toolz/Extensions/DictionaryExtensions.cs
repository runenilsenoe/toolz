namespace Tasks.Extensions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public static class DictionaryExtensions
{
    public static TValue? TryGet<TKey, TValue>(this Dictionary<TKey, TValue>? dictionary, TKey key) where TValue : class where TKey : notnull
    {
        return dictionary?.TryGetValue(key, out var value) ?? false 
            ? value : null;
    }
    public static TValue? TryGet<TKey, TValue>(this IDictionary<TKey, TValue>? dictionary, TKey key) where TValue : class
    {
        return dictionary?.TryGetValue(key, out var value) ?? false
            ? value : 
            null;
    }
    
    public static TValue? TryGet<TKey, TValue>(this KeyValuePair<TKey, TValue>[]? keyValuePairs, TKey key) where TValue : class
    {
        return keyValuePairs?.FirstOrDefault(kvp => kvp.Key?.Equals(key) is true).Value;
    }
    
}