using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private bool revert;
    private const float speed = 3f;

    private void Update()
    {
        transform.Translate(new Vector2(-speed * ((revert) ? (-1f) : (1f)), 0f) * Time.deltaTime);
        if (transform.position.x < -27f)
            transform.Translate(new Vector2(72f * ((revert) ? (-1f) : (1f)), 0f));
    }
}
