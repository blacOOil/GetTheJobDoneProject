using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class DataVisuals : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public List<GameObject> AnomalyDetected;
    public int ActiveThreatNum, ActiveOPNum, Containment;
    public TextMeshProUGUI ActiveThreatText, ActiveOPText,ContainmentText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        AnomalyDetected = gameEventManager.spawnedAnomalyList;
        ActiveThreatNum = AnomalyDetected.Count;
        ActiveThreatText.text = ActiveThreatNum.ToString();
        ActiveOPNum = GetActiveThreat();
        ActiveOPText.text = ActiveOPNum.ToString();
        ContainmentText.text = Containment.ToString();
    }
    public int GetActiveThreat()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (GameObject anomaly in AnomalyDetected)
        {
            var anomalyData = anomaly.GetComponent<AnomalySetting>();
            if (anomalyData != null && anomalyData.IsHandling)
            {
                list.Add(anomaly);
            }
        }

        return list.Count;
    }

}
