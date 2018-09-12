using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private const float speed = 3f;

    private void Update()
    {
        transform.Translate(new Vector2(-speed, 0f) * Time.deltaTime);
        if (transform.position.x < -27f)
            transform.Translate(new Vector2(54f, 0f));
    }
}
