using UnityEngine;

public class OperationBehavior : MonoBehaviour
{
    public string ItemName;
    public string ItemDescription;
    public int Item_Amount;
    public Sprite ItemImage;

    public bool MobilityHandle; // true = placement false = creature
    public bool forhabitat; // true = forest false = city
    public int anoTypeA, anoTypeB, anoTypeC; // e.g. A = Magical, B = Creature, C = Machine failure
}
