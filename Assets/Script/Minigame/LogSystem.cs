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
    public int LogState;
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

        LogProperty logproperty = SpawnedBacklog.GetComponent<LogProperty>();
        logproperty.TimerText = event_timer;
        eventname = anomalySetting.AnomalyEventName;
        logproperty.EventNameText = eventname;
        logproperty.anomalySetting = anomalySetting;
        logproperty.LogState = LogState;

    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
