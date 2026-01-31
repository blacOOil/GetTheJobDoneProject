using UnityEngine;

public class AlertButtonBehave : MonoBehaviour
{
    public bool IsPressed = false;
    public GameObject AlertMenu,EvacUI;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       AlertMenu.SetActive(false); 
       EvacUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AlertMenu.SetActive(IsPressed);
    }
    public void ToggleAlertMenu()
    {
        IsPressed = !IsPressed;
    }
    public void ConfirmButton(int num)
    {
        if(num == 1)
        {
            EvacUI.SetActive(true);
        }
        if (num == 2) 
        {
            IsPressed = !IsPressed;
        }
    }

}
