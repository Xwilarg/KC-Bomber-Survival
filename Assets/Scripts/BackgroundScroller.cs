using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private bool revert;
    private const float speed = 6f;

    private void Update()
    {
        // Put background next to each other and make them move (so we feel like we are flying)
        // Once background is out of screen (at the left), we put it back at the right of the screen
        transform.Translate(new Vector2(-speed * ((revert) ? (-1f) : (1f)), 0f) * Time.deltaTime);
        if (transform.position.x < -27f)
            transform.Translate(new Vector2(72f * ((revert) ? (-1f) : (1f)), 0f));
    }
}
