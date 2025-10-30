using UnityEngine;

public class Progress_ : MonoBehaviour
{

    public GameManager gameManager;
    public bool IsProgressSum;
    public GameObject SummarySheet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsProgressSum = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GameState == 3)
        {
            IsProgressSum=true;
        }
        else  
        {
            StopSumarry();
        }
        if (IsProgressSum)
        {
            StartSumarry();
        }
        
    }
    void StartSumarry()
    {
        SummarySheet.SetActive(true);
    }
    void StopSumarry()
    {
        IsProgressSum = false;
        SummarySheet.SetActive(false);
    }
}
