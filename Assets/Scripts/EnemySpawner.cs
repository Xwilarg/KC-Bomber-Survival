using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySeaplane;

    private readonly Vector2 refTimer = new Vector2(3f, 6f);
    private float timer;

    private readonly Vector2[][] formations = new Vector2[][] {
        Single(), Triangle(), VerLine(), HorLine()
    };

    private void Start()
    {
        timer = Random.Range(refTimer.x, refTimer.y);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = Random.Range(refTimer.x, refTimer.y);
            float y = Random.Range(-3f, 3f);
            foreach (Vector2 v in formations[Random.Range(0, formations.Length)])
                Destroy(Instantiate(enemySeaplane, v + new Vector2(15f, y), Quaternion.identity), 10f);
        }
    }

    private static Vector2[] Single()
    {
        return (new Vector2[] { new Vector2(0f, 0f) });
    }

    private static Vector2[] Triangle()
    {
        return (new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, .5f), new Vector2(1f, -.5f),
                                new Vector2(2f, 0f), new Vector2(2f, -1f), new Vector2(2f, 1f)});
    }

    private static Vector2[] VerLine()
    {
        return (new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, -.5f), new Vector2(0f, .5f),
                                new Vector2(0f, -1f), new Vector2(0f, 1f)});
    }

    private static Vector2[] HorLine()
    {
        return (new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(2f, 0f),
                                new Vector2(3f, 0f), new Vector2(4f, 0f)});
    }
}