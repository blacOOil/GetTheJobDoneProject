using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int GameState,maxGameStated;
    public float Timer;
    public bool Isworkdone, IsCounting;
    public bool IsStartWorking;
    public ExitDoors exitDoors;
    public GameObject player,HCamera;
    public Transform HouseTp,OfficeTp;
   

    public float startTime = 60f; // starting time in seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameState = 0;
        IsStartWorking = false;
        Timer = startTime;
        HCamera.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (exitDoors.IsExitOffice)
        {
            Isworkdone = false;

            Timer = 1;  
            GameState++;

        }
        if (GameState == 1)
        {
            HCamera.SetActive(false);
            IsStartWorking = true;
            Isworkdone = false;
        }
        if (IsStartWorking)
        {
            Timer -= Time.deltaTime;
            IsCounting = true;
        }
        if (Timer > 0)
        {
            Isworkdone = false;
        }
        else if (Timer <= 0)
        {
            Timer = 0; 
            Isworkdone = true;
        }
        if (Isworkdone) 
        {
            IsStartWorking = false ;
            IsCounting = false;
            GameState = 2;
           
        }
        if(GameState == 4)
        {
            player.transform.position = HouseTp.position;
            HCamera.SetActive(true);
            GameState++;
        }
        if (GameState == 6) 
        {
            player.transform.position = OfficeTp.position;
            HCamera.SetActive(false);
            GameState++;

        }
        if(GameState == 3)
        {
            IsCounting = false;
        }
        if (GameState >= maxGameStated) 
        {
            GameState = 0;
        }

    }
    public void NextState()
    {
        exitDoors.IsExitOffice = false;
        GameState++;
    }
}