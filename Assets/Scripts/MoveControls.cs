using UnityEngine;

public class MoveControls : MonoBehaviour
{
    [SerializeField]
    private PlaneController player;
    private RectTransform rect;
    private Camera cam;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        cam = Camera.main;
    }

    private void Update()
    {
        Rect r = new Rect(new Vector2(rect.position.x, rect.position.y) - rect.sizeDelta / 2, rect.sizeDelta);
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if (Input.GetMouseButton(0) && r.Contains(Input.mousePosition))
            player.Move(-(rect.position - Input.mousePosition) / (rect.sizeDelta.x / 2));
#elif UNITY_ANDROID || UNITY_IOS
        foreach (Touch t in Input.touches)
        {
            if (r.Contains(t.position))
                player.Move(-(new Vector2(rect.position.x, rect.position.y) - t.position) / (rect.sizeDelta.x / 2));
        }
#endif
    }
}
