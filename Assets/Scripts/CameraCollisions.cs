using UnityEngine;

public class CameraCollisions : MonoBehaviour
{
    private void Start()
    {
        Camera cam = Camera.main;
        Vector2 camSize = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));

        GameObject go = new GameObject("Left collision", typeof(BoxCollider2D));
        go.GetComponent<BoxCollider2D>().size = new Vector2(1f, camSize.y * 2f);
        go.transform.position = new Vector2(-camSize.x - .5f, 0f);
        go.tag = "Border";

        go = new GameObject("Right collision", typeof(BoxCollider2D));
        go.GetComponent<BoxCollider2D>().size = new Vector2(1f, camSize.y * 2f);
        go.transform.position = new Vector2(camSize.x + .5f, 0f);
        go.tag = "Border";

        go = new GameObject("Down collision", typeof(BoxCollider2D));
        go.GetComponent<BoxCollider2D>().size = new Vector2(camSize.x * 2f, 1f);
        go.transform.position = new Vector2(0f, -camSize.y - .5f);
        go.tag = "Border";

        go = new GameObject("Up collision", typeof(BoxCollider2D));
        go.GetComponent<BoxCollider2D>().size = new Vector2(camSize.x * 2f, 1f);
        go.transform.position = new Vector2(0f, camSize.y + .5f);
        go.tag = "Border";
    }
}
