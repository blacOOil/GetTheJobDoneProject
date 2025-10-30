using UnityEngine;

public class AlertButtonScript : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public GameObject followUpUIPrefab;
    public Transform UISpawner;
    public AnomalySetting anomalySetting; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gameEventManager = GameObject.Find("GameManager").GetComponent<GameEventManager>();
        UISpawner = GameObject.Find("MinigameSpawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
