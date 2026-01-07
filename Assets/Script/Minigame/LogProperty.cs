using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
public class LogProperty : MonoBehaviour
{
    public TextMeshProUGUI Time, EventName;
    public string TimerText, EventNameText;
    public AnomalySetting anomalySetting;
    public GameObject followUpUIPrefab;
    public Transform UISpawner;
    public Image Log_image;

    public int LogState;
    public List<Sprite> LogImageList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UISpawner = GameObject.Find("MinigameSpawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
  
        Time.text = TimerText;
        EventName.text = EventNameText;
        Log_image.sprite = LogImageList[LogState];

        if(LogState != anomalySetting.AnomalyState)
        {
            Destroy(gameObject);
        }
    }
    public void VISpawned()
    {
        if (!anomalySetting.IsFiledOpened)
        {    
            GameObject uiInstance = Instantiate(followUpUIPrefab, UISpawner.position, UISpawner.rotation, UISpawner);
            Default_Minigame minigame = uiInstance.GetComponent<Default_Minigame>();
            minigame.anomalysetted = anomalySetting;
            minigame.TypeOfConsole = 0;
            anomalySetting.IsFiledOpened = true;
        }


    }
}
