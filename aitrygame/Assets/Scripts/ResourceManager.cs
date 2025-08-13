using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    public event Action<int> OnResourceChanged;

    private int resources;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddResource(int amount)
    {
        resources += amount;
        OnResourceChanged?.Invoke(resources);
    }
}
