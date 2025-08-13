using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public List<string> buildings = new List<string>();
}

public static class SaveSystem
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save(SaveData data)
    {
        try
        {
            var json = JsonUtility.ToJson(data);
            File.WriteAllText(SavePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save game: {e}");
        }
    }

    public static SaveData Load()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                var json = File.ReadAllText(SavePath);
                return JsonUtility.FromJson<SaveData>(json);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load game: {e}");
        }
        return new SaveData();
    }
}

