using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Powerup : MonoBehaviour {

	private enum Type
    {
        Health,
        MainGun,
        SubGun
    }

    [SerializeField]
    private Type type;

    private const float speed = 100f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(-speed, 0f) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) // TODO: Powerup disappear ?
    {
        if (collision.CompareTag("Player"))
        {
            PlaneController player = collision.GetComponent<PlaneController>();
            if (type == Type.Health)
                player.RefillHealth();
            else if (type == Type.MainGun)
                player.RefillMain();
            else
                player.RefillSub();
            Destroy(gameObject);
        }
    }
}
