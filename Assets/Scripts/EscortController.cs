using UnityEngine;

public class EscortController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private float offsetY;

    private void Start()
    {
        offsetY = transform.position.y - player.transform.position.y;
    }

    private void Update()
    {
        // Escort planes follow the player on the Y axis
        transform.position = new Vector2(transform.position.x, player.position.y + offsetY);
    }
}
