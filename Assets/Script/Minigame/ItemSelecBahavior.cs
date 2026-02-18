using UnityEngine;
using UnityEngine.UI;

public class ItemSelecBahavior : MonoBehaviour
{
    public OperationBehavior OperationBehavior;
    public Image ItemImage;
    public GameObject Plusbutton;

    public bool Iselected = false;

    public OperationBehavior operationItem;
    public Sprite ItemImageSprite;
    public int Item_Amount;
    public bool MobilityHandle; // true = placement false = creature
    public bool forhabitat; // true = forest false = city
    public int anoTypeA, anoTypeB, anoTypeC; // e.g. A = Magical, B = Creature, C = Machine failure
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            Plusbutton.SetActive(!Iselected);

    }

}
