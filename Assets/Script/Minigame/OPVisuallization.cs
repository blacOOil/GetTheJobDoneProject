using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class OPVisuallization : MonoBehaviour
{
    public List<GameObject> Anomalylist;
    public List<GameObject> ALertPrefab;
    public LogSystem logsystem;
    public Transform SpawnPlace;


    [Header("Settings")]
    public float refreshInterval = 1f; 
    private float refreshTimer = 0f;

    private HashSet<GameObject> previousAnomalies = new HashSet<GameObject>();
    private HashSet<GameObject> handledAnomalies = new HashSet<GameObject>();
    private HashSet<GameObject> ContainedAnomalies = new HashSet<GameObject>();

    public MinigameSpawner minigameSpawner;
    [Header("Map Spawn Location")]
    public Map_Viz map_viz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshAnomalyList(); // Initial scan
    }

    // Update is called once per frame
    void Update()
    {
        refreshTimer += Time.deltaTime;

        // Refresh every interval (e.g. every 1 second)
        if (refreshTimer >= refreshInterval)
        {
            RefreshAnomalyList();
            RefreshHandledAnomalyList();
            RefreshCotainingAnomalyList();
            refreshTimer = 0f;
        }

        // (Optional) Clean nulls if anomalies get destroyed mid-frame
        Anomalylist = Anomalylist.Where(a => a != null).ToList();

    }
    public void RefreshAnomalyList()
    {
        // Find all anomalies
        GameObject[] foundAnomalies = GameObject.FindGameObjectsWithTag("anomaly");

        // Detect new anomalies
        foreach (GameObject anomaly in foundAnomalies)
        {
            AnomalySetting anomalysetting = anomaly.GetComponent<AnomalySetting>();
            if (!previousAnomalies.Contains(anomaly) )
            {
                // New anomaly detected
                AlertIconSpawning(Random.Range(0, ALertPrefab.Count),anomaly.GetComponent<AnomalySetting>());
                previousAnomalies.Add(anomaly);
                logsystem.SpawnedBlackLog(anomalysetting);
                int anomalystate = anomalysetting.AnomalyState;
                logsystem.LogState = anomalystate;
               
            }  
        }

        previousAnomalies.RemoveWhere(a => a == null);
        // Clean list and update current anomalies
        Anomalylist.Clear();
        Anomalylist.AddRange(foundAnomalies);
    }
    public void RefreshHandledAnomalyList()
    {
        GameObject[] foundAnomalies = GameObject.FindGameObjectsWithTag("anomaly");

        foreach (GameObject anomaly in foundAnomalies)
        {
            if (anomaly == null) continue;

            AnomalySetting anomalysetting = anomaly.GetComponent<AnomalySetting>();

            // Handling just started
            if (anomalysetting.IsHandling && !handledAnomalies.Contains(anomaly))
            {
                handledAnomalies.Add(anomaly);

                logsystem.SpawnedBlackLog(anomalysetting);
                logsystem.LogState = anomalysetting.AnomalyState;

                // 
                previousAnomalies.Remove(anomaly);
            }
        }

        // Cleanup destroyed objects
        handledAnomalies.RemoveWhere(a => a == null);
    }
    public void RefreshCotainingAnomalyList()
    {
        GameObject[] foundAnomalies = GameObject.FindGameObjectsWithTag("anomaly");

        foreach (GameObject anomaly in foundAnomalies)
        {
            if (anomaly == null) continue;

            AnomalySetting anomalysetting = anomaly.GetComponent<AnomalySetting>();

            // Handling just started
            if (anomalysetting.IsContained && !ContainedAnomalies.Contains(anomaly))
            {
                ContainedAnomalies.Add(anomaly);

                logsystem.SpawnedBlackLog(anomalysetting);
                logsystem.LogState = anomalysetting.AnomalyState;

                // 
                previousAnomalies.Remove(anomaly);
            }
        }

        // Cleanup destroyed objects
        ContainedAnomalies.RemoveWhere(a => a == null);
    }

    public void AlertIconSpawning(int indexIcon,AnomalySetting anomaly)
    {
        if (indexIcon < 0 || indexIcon >= ALertPrefab.Count)
        {
            Debug.LogWarning("Invalid Alert Icon Index!");
            return;
        }
        GetSpawnPostion(anomaly);
        // Spawn alert icon under WorldMap
        GameObject alert = Instantiate(ALertPrefab[indexIcon], SpawnPlace);
        alert.GetComponent<AlertButtonScript>().anomalySetting = anomaly;
        
    }
    public void GetSpawnPostion(AnomalySetting anomaly)
    {
        int anomalycountryId = anomaly.CountryId;
        List<Transform> countryTranformList = map_viz.CountryTranformList;
        SpawnPlace = countryTranformList[anomalycountryId];
    }

}
