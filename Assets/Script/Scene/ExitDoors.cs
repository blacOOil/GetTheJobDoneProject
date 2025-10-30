using UnityEngine;

public class ExitDoors : MonoBehaviour
{
    public GameManager gameManager;
    public float PlayerCheckerRadius;
    public bool Isworkdone,IsExitOffice;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsExitOffice = false;
    }

    // Update is called once per frame
    void Update()
    {
        Isworkdone = gameManager.Isworkdone;
        if ((Isworkdone) && IsplayerClose())
        {
                ExitOffice();
        }
        else
        {
            IsExitOffice = false;
        }
    }
    public void ExitOffice()
    {
        IsExitOffice=true;
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
