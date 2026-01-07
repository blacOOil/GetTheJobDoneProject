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
    public float refreshInterval = 1f; // Update every 1 second
    private float refreshTimer = 0f;

    private HashSet<GameObject> previousAnomalies = new HashSet<GameObject>();

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
            if (!previousAnomalies.Contains(anomaly))
            {
                // New anomaly detected
                AlertIconSpawning(Random.Range(0, ALertPrefab.Count),anomaly.GetComponent<AnomalySetting>());
                previousAnomalies.Add(anomaly);
                logsystem.SpawnedBlackLog(anomaly.GetComponent<AnomalySetting>());
                logsystem.LogState = 0;
            }
        }

        // Clean list and update current anomalies
        Anomalylist.Clear();
        Anomalylist.AddRange(foundAnomalies);
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
