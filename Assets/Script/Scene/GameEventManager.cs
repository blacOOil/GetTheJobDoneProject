using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameEventManager : MonoBehaviour
{
    public GameManager gameManager;
    public bool IsAnomalyStarted;
    public int gamestate,AnomalyIndex;
    public List<int> spawnedAnomalyIndex;
    public List<GameObject> spawnedAnomalyList;
    public List<GameObject> anomalyPrefabs;
    public Transform anomalySpawner;

    [Header("Spawn Timer")]
    public float spawnInterval;   // seconds between spawns
    public float spawnTimer = 0f;      // counts up each frame

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsAnomalyStarted = false;
        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gamestate = gameManager.GameState;
        if(gamestate == 1)
        {
            IsAnomalyStarted = true;

        }
        if (IsAnomalyStarted)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                AnomalyIndex = 0;
                spawnAnomaly(AnomalyIndex);
                spawnTimer = 0f;
            }
               
        }
    }

    public void spawnAnomaly(int AnomalyIndex)
    {
        GameObject anomaly = Instantiate(anomalyPrefabs[AnomalyIndex], anomalySpawner);
        spawnedAnomalyIndex.Add(AnomalyIndex);
        spawnedAnomalyList.Add(anomaly);
    }
}
