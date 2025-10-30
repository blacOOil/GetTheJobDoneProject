using System.Collections.Generic;
using UnityEngine;


public class MinigameSpawner : MonoBehaviour
{
    public List<GameObject> MinigamePrefab;
    public bool IsgameStart;
    public CameraSwitcher CameraSwitcher;
    public GameManager gamemanager;

    public Transform spawnPoint; // Position to spawn the object
    public Transform spawnParent;
    public float spawnRadius = 5f;    // Random area radius
    public float spawnInterval = 2f; // Time between spawns
    public int spawnCount = 3;        // How many to spawn each interval
    public int maxSpawn = 20;  // maximum total spawned objects

    private float timer;
    private int totalSpawned = 0; // track how many spawned

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsgameStart = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        IsgameStart = CameraSwitcher.IsgameStarted;
        if (IsgameStart)
        {
            timer = gamemanager.Timer;
            if (timer >= spawnInterval && totalSpawned < maxSpawn)
            {
                timer = 0f;
               // SpawnRandomObject();
            }
            
        }
    }

    public void SpawnRandomObject()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            if (totalSpawned >= maxSpawn)
                return;

            int randomIndex = Random.Range(0, MinigamePrefab.Count);
            GameObject prefabToSpawn = MinigamePrefab[randomIndex];

            Vector3 randomPos = spawnPoint.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius),
                0
            );
           

            // Instantiate with parent
            GameObject newObj = Instantiate(prefabToSpawn, randomPos, Quaternion.identity, spawnParent);

            totalSpawned++;
        }

        Debug.Log($"Spawned {totalSpawned}/{maxSpawn} as children of {spawnParent.name}");
    }
    public void SpawnCodexObject(int Codex)
    {
        GameObject prefabToSpawn = MinigamePrefab[Codex];
        // Instantiate with parent
        GameObject newObj = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, spawnParent);
    }
}
