using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public int resources = 100;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool Spend(int amount)
    {
        if (resources < amount) return false;
        resources -= amount;
        return true;
    }

    public void Add(int amount)
    {
        resources += amount;
    }
}
