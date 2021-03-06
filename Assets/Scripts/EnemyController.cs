﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private int health;
    private PlaneController player;
    private GameObject powerup;
    private const float speed = -10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sortingOrder = 1000 - (int)(transform.position.y * 10f);
    }

    public void SetPlayer(PlaneController pc, GameObject p)
    {
        player = pc;
        powerup = p;
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }

    private void OnDestroy()
    {
        if (powerup != null)
            Destroy(Instantiate(powerup, transform.position, Quaternion.identity), 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(30);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Escort")) // One shot escort
        {
            player.DamageEscort();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Bullet")) // Take damage
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
