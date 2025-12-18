
using UnityEngine;
using System.Collections.Generic;

public class AnomalySetting : MonoBehaviour
{
    [Header("Anomaly Info")]
    public string AnomalyEventName;
    public string AnomalyEventDes;
    public string AnomalyName;
    public string AnomalyDes;
    public float AnomalyPlace;

    [Header("Anomaly Parameters")]
    public int AnomalyType;          // e.g. 0 = Ghost, 1 = Creature, 2 = Machine failure
    public float Behavior;           // behavior intensity or randomness
    public float ThreatLevel;        // value to represent danger level (0–10)
    public Sprite AnomalyImage;      // image or icon for UI

    [Header("Runtime State")]
    public float AnomalyTimer;       // how long this anomaly has been active
    public float AnomalyState;       // current state (0 = inactive, 1 = active, 2 = resolved)
    public bool IsHandling;          // true when being handled by team
    public bool IsContained;         // true when fully contained/resolved

    public bool IsFiledOpened;

    [Header("Handled State")]
    public List<GameObject> OperativeItem;

    [Header("Location State")]
    public string CountryName;
    public string AddressName;
    public int CountryId;
    public int AddressId;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnomalyState = 0;
        AnomalyTimer = 0;
        IsHandling = false;
        IsContained = false;
        IsFiledOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
       AnomalyTimer += Time.deltaTime;
        if (IsHandling) 
        {
            
        }
        if (IsContained) 
        {
            
        }
    }
}
