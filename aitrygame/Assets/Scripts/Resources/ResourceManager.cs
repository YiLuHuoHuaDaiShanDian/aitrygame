using System;
using System.Collections.Generic;

/// <summary>
/// Manages game resources and provides events for changes.
/// </summary>
public class ResourceManager
{
    private readonly Dictionary<string, int> _resources = new();

    /// <summary>
    /// Event invoked when a resource amount changes.
    /// </summary>
    public event Action<string, int> ResourceChanged;

    /// <summary>
    /// Adds or subtracts the specified amount for a resource type.
    /// </summary>
    public void AddResource(string type, int amount)
    {
        if (!_resources.ContainsKey(type))
        {
            _resources[type] = 0;
        }

        _resources[type] += amount;
        ResourceChanged?.Invoke(type, _resources[type]);
    }

    /// <summary>
    /// Gets the current amount of the specified resource type.
    /// </summary>
    public int GetResource(string type)
    {
        return _resources.TryGetValue(type, out var value) ? value : 0;
    }
}
