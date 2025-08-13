using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SaveData SaveData { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SaveData = SaveSystem.Load();
        InitializeSystems();
    }

    private void InitializeSystems()
    {
        Debug.Log("Resource system initialized.");
        Debug.Log("Save system initialized.");
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        // TODO: Advance main loop using deltaTime
    }

    public void AddResource(string resource, int amount)
    {
        if (SaveData.resources.ContainsKey(resource))
            SaveData.resources[resource] += amount;
        else
            SaveData.resources[resource] = amount;
    }

    public int GetResource(string resource)
    {
        return SaveData.resources.TryGetValue(resource, out var value) ? value : 0;
    }

    public bool SpendResource(string resource, int amount)
    {
        int current = GetResource(resource);
        if (current < amount) return false;
        SaveData.resources[resource] = current - amount;
        return true;
    }

    public void AddBuilding(string buildingId)
    {
        SaveData.buildings.Add(buildingId);
    }

    public void SaveGame()
    {
        SaveSystem.Save(SaveData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
