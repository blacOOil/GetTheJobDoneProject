
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
    public bool IsAnomalymobility; // true = movable false = placement
    public int IsEventCrowed;      // 1 = in the City 2 = in  the forest
    public int anoTypeA, anoTypeB,anoTypeC; // e.g. A = Magical, B = Creature, C = Machine failure
    public float BehaviorFriendly,BehaviorRule, BehaviorAggressive, BehaviorRandomness;      
    public float ThreatLevel;        // value to represent danger level (0–10)
    public Sprite AnomalyImage;      // image or icon for UI

    [Header("Runtime State")]
    public float AnomalyTimer;       // how long this anomaly has been active
    public float AnomalyState;       // current state (0 = inactive, 1 = active, 2 = resolved)
    public bool IsHandling;          // true when being handled by team
    public bool IsContained;         // true when fully contained/resolved

    public bool IsFiledOpened;

    [Header("Handled State")]
    public OperationhandleSystem operationhandler;
    public OPnAnomalyCal oPnAnomaly;
    public int Opresult = 0 ;
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
        if(operationhandler != null)
        {
            operationhandler = oPnAnomaly.OperationhandleSystem;
            IsHandling = true;
        }
        if (IsHandling) 
        {
            Opresult = oPnAnomaly.startoperationCalculation();
        }
        if (IsContained) 
        {
            
        }
    }
}
