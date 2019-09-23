using UnityEngine;

public class EscortController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private float offsetY;
    private bool followPlayer;

    private void Start()
    {
        followPlayer = false;
    }

    private void Update()
    {
        if (!followPlayer || player == null)
            return;
        // Escort planes follow the player on the Y axis
        transform.position = new Vector2(transform.position.x, player.position.y + offsetY);
    }

    public void StartFlying()
    {
        offsetY = transform.position.y - player.transform.position.y;
    }
}
