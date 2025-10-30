using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public PlayerMovment playerMovment;
    public GameManager gameManager;
    public bool IsgameStarted;
    public GameObject Cam1, Cam2, Start_Button;
    public float PlayerCheckerRadius;
    public int GameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsgameStarted = false;
        Start_Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameState = gameManager.GameState;
        if (IsplayerClose())
        {
            Start_Button.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                if (GameState == 0)
                {
                    IsgameStarted = true;
                    gameManager.GameState++;
                }
            }
            if(GameState == 2)
            {
                IsgameStarted = false;
                playerMovment.IsMoveable = true;
            }
        }
        if (IsgameStarted)
        {
            playerMovment.IsMoveable = false;
            Cam2.SetActive(true);
            Cam1.SetActive(false);

        }
        else
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
    }

    private bool CheckProximity(string tag)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, PlayerCheckerRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(tag))
                return true;
        }
        return false;
    }

    public bool IsplayerClose()
    {
        return CheckProximity("Player");
    }


}
