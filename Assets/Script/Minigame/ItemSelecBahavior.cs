using UnityEngine;
using UnityEngine.UI;

public class ItemSelecBahavior : MonoBehaviour
{
    public OperationBehavior OperationBehavior;
    public Image ItemImage;
    public GameObject Plusbutton;

    public bool Iselected = false;
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
