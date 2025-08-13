using UnityEngine;

public class GameManager : MonoBehaviour
{
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

