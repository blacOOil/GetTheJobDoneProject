using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public GameObject OperationUInventor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void OpenInventory()
    {
        OperationUInventor.SetActive(true);
    }
    public void CloseInventory() {  OperationUInventor.SetActive(false);}

}
