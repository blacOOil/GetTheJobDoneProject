using UnityEngine;
using System.Collections.Generic;

public class ActionButton : MonoBehaviour
{
    public GameObject OperationUInventor;
    public Default_Minigame default_Minigame;
    public AnomalySetting anomalySetting;
    public List<GameObject> ItemtoDeploy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        anomalySetting = default_Minigame.anomalysetted; 
    }
    public void OpenInventory()
    {
        OperationUInventor.SetActive(true);
    }
    public void CloseInventory() {  OperationUInventor.SetActive(false);}

    public void Deployment()
    {
        anomalySetting.IsHandling = true;
    }

}
