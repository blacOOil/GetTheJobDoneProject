using UnityEngine;

public class LogSystem : MonoBehaviour
{
    public OPVisuallization oPVisuallization;
    public GameEventManager gameEventManager;
    public float Timer;
    public GameObject BackLogButton_Prefab;
    public GameObject Incident_Report;

    public string event_timer, eventname;
    public float ClockSpeed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEventManager.IsAnomalyStarted)
        {
            Timer += Time.deltaTime * ClockSpeed;
        }
      
    }
    public void SpawnedBlackLog(AnomalySetting anomalySetting)
    {
        GameObject SpawnedBacklog = Instantiate(BackLogButton_Prefab, Incident_Report.transform);
        event_timer = FormatTime(Timer);
        SpawnedBacklog.GetComponent<LogProperty>().TimerText = event_timer;
        eventname = anomalySetting.AnomalyEventName;
        SpawnedBacklog.GetComponent <LogProperty>().EventNameText = eventname;
        SpawnedBacklog.GetComponent<LogProperty>().anomalySetting = anomalySetting;

    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
