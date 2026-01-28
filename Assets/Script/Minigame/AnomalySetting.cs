
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
    public int IsEventCrowed;      // poppulation of Civilion around anomaly 0 No people 5 Urban area 10 Big city area
    public int anoPhysicalScore, anoMagicalScore,anopsychicScore; // e.g. A = Physical 0-10, B = Magical 0-10, C = Psycho 0-10
    public float BehaviorAggressionScore,BehaviorRandomnessScore;      
    public float ThreatLevel;        // value to represent danger level (0–10)
    public Sprite AnomalyImage;      // image or icon for UI

    [Header("Runtime State")]
    public float AnomalyTimer;       // how long this anomaly has been active
    public int AnomalyState;       // current state 0 = threat, 1 = Handling, 2 = Contained)
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
            AnomalyState = 1;
            Opresult = oPnAnomaly.startoperationCalculation();
        }
        if (IsContained) 
        {
            AnomalyState = 2;
        }
    }
}
