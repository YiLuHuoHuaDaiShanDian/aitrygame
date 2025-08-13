using UnityEngine;

public class BuildButton : MonoBehaviour
{
    public void OnClick()
    {
        if (BuildingPlacer.Instance != null)
        {
            BuildingPlacer.Instance.EnterPlacementMode();
        }
    }
}
