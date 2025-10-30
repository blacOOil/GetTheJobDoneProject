using UnityEngine;
using System.Collections.Generic;
public class InventoryVisualization : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject ItemInventor_Prefab;
    public Inventory inventory_Data;

    [Header("Spawn Settings")]
    public Transform inventoryUIParent; // Optional: assign where to spawn in hierarchy
    private List<GameObject> spawnedItems = new List<GameObject>();
    private int lastItemCount = 0;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        inventory_Data = GameManager.GetComponent<Inventory>();
    }

    void Update()
    {
        if (inventory_Data == null) return;

        // Check for new items added to the Inventory
        if (inventory_Data.Operation.Count > lastItemCount)
        {
            // Spawn new visual items for each new entry
            for (int i = lastItemCount; i < inventory_Data.Operation.Count; i++)
            {
                GameObject newItem = Instantiate(ItemInventor_Prefab, inventoryUIParent);
                spawnedItems.Add(newItem);
            }

            // Update count
            lastItemCount = inventory_Data.Operation.Count;
        }

        // (Optional) Handle removed items
        if (inventory_Data.Operation.Count < lastItemCount)
        {
            int itemsToRemove = lastItemCount - inventory_Data.Operation.Count;
            for (int i = 0; i < itemsToRemove; i++)
            {
                if (spawnedItems.Count > 0)
                {
                    GameObject item = spawnedItems[spawnedItems.Count - 1];
                    spawnedItems.RemoveAt(spawnedItems.Count - 1);
                    Destroy(item);
                }
            }

            lastItemCount = inventory_Data.Operation.Count;
        }
    }
}
