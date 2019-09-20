using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Control button call the corresponding function on the player when pressed
    [SerializeField]
    private UnityEvent toCall;
    private bool isDown;

    private void Start()
    {
        isDown = false;
    }

    private void Update()
    {
        if (isDown)
            toCall.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
