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
        ActiveThreatNum = GetActiveThreat(0);
        ActiveThreatText.text = ActiveThreatNum.ToString();
        ActiveOPNum = GetActiveThreat(1);
        ActiveOPText.text = ActiveOPNum.ToString();
        Containment = GetActiveThreat(2);
        ContainmentText.text = Containment.ToString();
    }
    public int GetActiveThreat(int AnomalyState)
    {
        List<GameObject> list = new List<GameObject>();

        foreach (GameObject anomaly in AnomalyDetected)
        {
            var anomalyData = anomaly.GetComponent<AnomalySetting>();
            if (anomalyData != null && (anomalyData.AnomalyState == AnomalyState))
            {
                list.Add(anomaly);
            }
            else
            {
                list.Remove(anomaly);
            }
        }

        return list.Count;
    }

}
