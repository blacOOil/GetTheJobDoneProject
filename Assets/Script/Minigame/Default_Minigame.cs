using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Default_Minigame : MonoBehaviour
{
    public int TypeOfConsole;
    public AnomalySetting anomalysetted;
    public GameObject foundedUI;
    public GameObject InventoryUi;
    public TextMeshProUGUI Eventname, EventDes;
    public Image EventImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foundedUI.SetActive(false);
        InventoryUi.SetActive(false);
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
        Eventname.text = anomalysetted.AnomalyEventName;
        EventDes.text = anomalysetted.AnomalyEventDes;
        EventImage.sprite = anomalysetted.AnomalyImage;

    }
    public void ToggleSupportNeeded()
    {
      
    }

    public void CloseWindow()
    {
        anomalysetted.IsFiledOpened = false;
        Destroy(gameObject);
    }

}
