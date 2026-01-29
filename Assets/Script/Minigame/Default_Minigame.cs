using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Default_Minigame : MonoBehaviour
{
    public int TypeOfConsole;
    public AnomalySetting anomalysetted;
    public GameObject foundedUI;
    public GameObject InventoryUi,OperationSupportUi,ContainmentUI,ActionMakingUi;
    public TextMeshProUGUI Eventname, EventDes,SupEventName,SupEventDes,AnomalyName;
    public Image EventImage,AnomalyImage;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foundedUI.SetActive(false);
        InventoryUi.SetActive(false);
        OperationSupportUi.SetActive(false);
        ContainmentUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (anomalysetted != null) 
        {
          if(TypeOfConsole == 0)
            {
                ToggleAlertFounded();
            }
            if (TypeOfConsole == 1) 
            {
                ToggleSupportNeeded();
            }
            if(TypeOfConsole == 2)
            {
                ToggleContainmented();
            }
        }
    }
    public void Openwindow(int Get_TypeofConsole, AnomalySetting anomalySetting)
    {
        anomalysetted = anomalySetting;
        TypeOfConsole = Get_TypeofConsole;
    }
   public void ToggleAlertFounded()
    {
        foundedUI.SetActive(true);
        ActionMakingUi.SetActive(true);
        Eventname.text = anomalysetted.AnomalyEventName;
        EventDes.text = anomalysetted.AnomalyEventDes;
        EventImage.sprite = anomalysetted.AnomalyImage;

    }
    public void ToggleSupportNeeded()
    {
        OperationSupportUi.SetActive(true);
        InventoryUi.SetActive(false);
        ActionMakingUi.SetActive(false);
        SupEventName.text = anomalysetted.AnomalyEventName;
        SupEventDes.text = anomalysetted.AnomalyDes;

    }
    public void ToggleContainmented()
    {
        ContainmentUI.SetActive(true);
        InventoryUi.SetActive(false);
        ActionMakingUi.SetActive(false);
        AnomalyName.text = anomalysetted.AnomalyName;
        AnomalyImage.sprite = anomalysetted.AnomalyImage;

    }
    public void SendingSupport(int supportNumber)
    {
        anomalysetted.IsContained = true;
        CloseWindow();
    }

    public void CloseWindow()
    {
        anomalysetted.IsFiledOpened = false;
        Destroy(gameObject);
    }

}
