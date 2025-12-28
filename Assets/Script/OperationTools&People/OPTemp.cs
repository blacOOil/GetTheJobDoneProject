using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class OPTemp : MonoBehaviour
{
    public List<GameObject> ItemReadyPanel;
    public List<GameObject> ItemReadyList;
    public List<Image> ItemReadyImage;

    public GameObject SelectedItem;

    public OperationhandleSystem operationhandleSystem;
    public Default_Minigame default_Minigame;
    public AnomalySetting anomalySetting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (default_Minigame.anomalysetted != null) 
        {
            anomalySetting = default_Minigame.anomalysetted;
        }
    }
   
    public void DeployOperation()
    {
        anomalySetting.operationhandler = operationhandleSystem;
    }
}
