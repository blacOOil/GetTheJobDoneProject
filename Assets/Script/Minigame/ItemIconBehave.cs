using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIconBehave : MonoBehaviour
{

    public Image IconImage;
    public TextMeshProUGUI textMeshpro;
    public Sprite IconSprite;
    public int ItemAmount,ItemIndex;
    public OperationBehavior OperationBehavior;
    public InventoryVisualization inventoryVisualization;
    // Update is called once per frame
    void Update()
    {
        if (IconSprite != null)
        {
            IconImage.sprite = IconSprite;
        }
        textMeshpro.text = ItemAmount.ToString();

    }
    public void Visualizedata()
    {
        inventoryVisualization.ItemDataVisualIndex = ItemIndex;
    }
}
