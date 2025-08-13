using UnityEngine;

/// <summary>
/// Central game manager responsible for initializing core systems.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ResourceManager ResourceManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ResourceManager = new ResourceManager();
    }
}
