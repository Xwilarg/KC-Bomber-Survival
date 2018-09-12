using UnityEngine;
using UnityEngine.EventSystems;

public class MoveControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private PlaneController player;
    private bool isDown;

    private void Start()
    {
        isDown = false;
    }

    private void Update()
    {
        if (isDown)
            player.Move(Input.mousePosition - new Vector3(125f, 125f, 0f));
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
