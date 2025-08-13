using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeSystems();
    }

    private void InitializeSystems()
    {
        InitializeResourceSystem();
        InitializeSaveSystem();
    }

    private void InitializeResourceSystem()
    {
        // TODO: Initialize resource system
        Debug.Log("Resource system initialized.");
    }

    private void InitializeSaveSystem()
    {
        // TODO: Initialize save system
        Debug.Log("Save system initialized.");
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        // TODO: Advance main loop using deltaTime
    }
    
    public SaveData saveData;

    private void Awake()
    {
        saveData = SaveSystem.Load();
    }

    public void AddResource(string resource, int amount)
    {
        if (saveData.resources.ContainsKey(resource))
            saveData.resources[resource] += amount;
        else
            saveData.resources[resource] = amount;
    }

    public int GetResource(string resource)
    {
        return saveData.resources.TryGetValue(resource, out var value) ? value : 0;
    }

    public void AddBuilding(string buildingId)
    {
        saveData.buildings.Add(buildingId);
    }

    public void SaveGame()
    {
        SaveSystem.Save(saveData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}

