using UnityEngine;
using System.Collections.Generic;
public class InventoryVisualization : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject ItemInventor_Prefab;
    public Default_Minigame default_Minigame;
    public Inventory inventory_Data;
    public List<GameObject> InventoryList;


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
        InventoryList = inventory_Data.OperationItem;
        if (inventory_Data == null) return;

        // Check for new items added to the Inventory
        if (inventory_Data.OperationItem.Count > lastItemCount)
        {
            // Spawn new visual items for each new entry
            for (int i = lastItemCount; i < inventory_Data.OperationItem.Count; i++)
            {
                GameObject newItem = Instantiate(ItemInventor_Prefab, inventoryUIParent);
                ItemIconBehave newOB = newItem.GetComponent<ItemIconBehave>();
                GameObject ItemData = inventory_Data.OperationItem[i];
                newOB.IconSprite = ItemData.GetComponent<OperationBehavior>().ItemImage;
                newOB.ItemAmount = ItemData.GetComponent<OperationBehavior>().Item_Amount;
                newOB.OperationBehavior = ItemData.GetComponent<OperationBehavior>();
                newOB.ItemIndex = i;
                newOB.inventoryVisualization = gameObject.GetComponent<InventoryVisualization>();
                newOB.default_Minigame = default_Minigame;
                spawnedItems.Add(newItem);
            }

            // Update count
            lastItemCount = inventory_Data.OperationItem.Count;
        }

        // (Optional) Handle removed items
        if (inventory_Data.OperationItem.Count < lastItemCount)
        {
            int itemsToRemove = lastItemCount - inventory_Data.OperationItem.Count;
            for (int i = 0; i < itemsToRemove; i++)
            {
                if (spawnedItems.Count > 0)
                {
                    GameObject item = spawnedItems[spawnedItems.Count - 1];
                    spawnedItems.RemoveAt(spawnedItems.Count - 1);
                    Destroy(item);
                }
            }

            lastItemCount = inventory_Data.OperationItem.Count;
        }

    }
    public void VisualDataDetail(int IntemIdex)
    {
      // OperationBehavior ItemData = InventoryList[ItemDataVisualIndex].GetComponent<OperationBehavior>();
      // ItemNameText.text = ItemData.ItemName;
       // ItemDesText.text = ItemData.ItemDescription;
    }
}
