using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private int health;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sortingOrder = 1000 - (int)(transform.position.y * 10f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(-5f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        Destroy(collision.gameObject);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
