using UnityEngine;

public class ShelfPlacementManager : MonoBehaviour
{
    public GridSystem gridSystem;
    private GameObject currentShelfPrefab;
    private GameObject currentShelfInstance;

    private void Update()
    {
        if (currentShelfPrefab != null)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f; // Ensure it's in the 2D plane
            int x, y;
            gridSystem.GetXY(mouseWorldPosition, out x, out y);
            Vector3 gridPosition = gridSystem.GetWorldPosition(x, y);

            if (currentShelfInstance == null)
            {
                currentShelfInstance = Instantiate(currentShelfPrefab, gridPosition, Quaternion.identity);
            }
            else
            {
                currentShelfInstance.transform.position = gridPosition;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                currentShelfInstance.transform.Rotate(0, 0, 90);
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Finalize shelf placement
                currentShelfPrefab = null; // Or set to next shelf if you have a queue system
            }
        }
    }

    public void SetCurrentShelfPrefab(GameObject shelfPrefab)
    {
        this.currentShelfPrefab = shelfPrefab;
    }
}
