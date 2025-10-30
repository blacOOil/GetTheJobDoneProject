using UnityEngine;

public class BackToWork : MonoBehaviour
{
    public GameManager gameManager;
    public float PlayerCheckerRadius;
    public bool  IsBackOffice;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsBackOffice = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (IsplayerClose())
        {
            ExitHouse();
        }
        else
        {
            IsBackOffice = false;
        }
    }
    public void ExitHouse()
    {
        IsBackOffice = true;
        gameManager.GameState = 6;
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

