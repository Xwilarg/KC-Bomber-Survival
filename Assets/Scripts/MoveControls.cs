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
        float radius = rect.sizeDelta.x / 2;
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if (Input.GetMouseButton(0) && r.Contains(Input.mousePosition))
        {
            Vector2 clickPos = rect.position - Input.mousePosition;
            float dist = Vector2.Distance(Vector2.zero, clickPos);
            player.Move(-new Vector2((radius * clickPos.x) / dist, (radius * clickPos.y) / dist) / radius);
        }
#elif UNITY_ANDROID || UNITY_IOS
        foreach (Touch t in Input.touches)
        {
            if (r.Contains(t.position))
            {  
                Vector2 clickPos = new Vector2(rect.position.x, rect.position.y) - t.position;
                float dist = Vector2.Distance(Vector2.zero, clickPos);
                player.Move(-new Vector2((radius * clickPos.x) / dist, (radius * clickPos.y) / dist) / radius);
            }
        }
#endif
    }
}
