using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public Camera cam;
    public LayerMask groundMask;
    public Building buildingPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
            {
                if (ResourceManager.Instance.Spend(buildingPrefab.constructionCost))
                {
                    Building building = Instantiate(buildingPrefab);
                    building.Place(hit.point);
                }
                else
                {
                    Debug.Log("Not enough resources");
                }
            }
        }
    }
}
