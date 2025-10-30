using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Drag Settings")]
    public RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    void Start()
    {

        canvas = GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("UIDragHandler: No Canvas found in parent!");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }
     void Update()
    {
        if (isDragging)
        {
            rectTransform.position = GetMouseWorldPosition();
        }
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
