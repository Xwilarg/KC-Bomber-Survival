using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private int health;
    private PlaneController player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sortingOrder = 1000 - (int)(transform.position.y * 10f);
    }

    public void SetPlayer(PlaneController pc)
    {
        player = pc;
    }

    private void Update()
    {
        rb.velocity = new Vector2(-5f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(90);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Escort"))
        {
            player.DamageEscort();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
