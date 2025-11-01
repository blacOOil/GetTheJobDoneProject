using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIconBehave : MonoBehaviour
{
    public Default_Minigame default_Minigame;
    public Image IconImage;
    public TextMeshProUGUI textMeshpro;
    public Sprite IconSprite;
    public int ItemAmount,ItemIndex;
    public OperationBehavior OperationBehavior;
    public InventoryVisualization inventoryVisualization;

    [Header("TextOperty")]
    public TextMeshProUGUI ItemName,ItemDes;
    // Update is called once per frame
    void Update()
    {
        if (IconSprite != null)
        {
            IconImage.sprite = IconSprite;
        }
        textMeshpro.text = ItemAmount.ToString();
        ItemName.text = OperationBehavior.ItemName;
        ItemDes.text = OperationBehavior.ItemDescription;

    }
    public void AddtoDeployment()
    {
        inventoryVisualization.VisualDataDetail(ItemIndex);
    }

}
