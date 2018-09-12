using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySeaplane, torpedoBomber;
    [SerializeField]
    private PlaneController player;

    private struct EnemyPos
    {
        public EnemyPos(Vector2 pos, GameObject enemy)
        {
            this.pos = pos;
            this.enemy = enemy;
        }

        public Vector2 pos;
        public GameObject enemy;
    }

    private readonly Vector2 refTimer = new Vector2(2f, 4f);
    private float timer;

    private EnemyPos[][] formations;

    private void Start()
    {
        timer = Random.Range(refTimer.x, refTimer.y);
        formations = new EnemyPos[][] {
            Single(), Triangle(), VerLine(), HorLine(), Escort(), Diamand()
        };
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = Random.Range(refTimer.x, refTimer.y);
            float y = Random.Range(-3f, 3f);
            foreach (EnemyPos v in formations[Random.Range(0, formations.Length)])
            {
                GameObject go = Instantiate(v.enemy, v.pos + new Vector2(15f, y), Quaternion.identity);
                go.GetComponent<EnemyController>().SetPlayer(player);
                Destroy(go, 10f);
            }
        }
    }

    private EnemyPos[] Single()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(0f, 0f), enemySeaplane) });
    }

    private EnemyPos[] Triangle()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(0f, 0f), enemySeaplane), new EnemyPos(new Vector2(1f, .5f), enemySeaplane), new EnemyPos(new Vector2(1f, -.5f), enemySeaplane),
                                new EnemyPos(new Vector2(2f, 0f), enemySeaplane), new EnemyPos(new Vector2(2f, -1f), enemySeaplane), new EnemyPos(new Vector2(2f, 1f), enemySeaplane) });
    }

    private EnemyPos[] VerLine()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(0f, 0f), enemySeaplane), new EnemyPos(new Vector2(0f, .5f), enemySeaplane), new EnemyPos(new Vector2(0f, -.5f), enemySeaplane),
                                new EnemyPos(new Vector2(0f, -1f), enemySeaplane), new EnemyPos(new Vector2(0f, 1f), enemySeaplane) });
    }

    private EnemyPos[] HorLine()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(0f, 0f), enemySeaplane), new EnemyPos(new Vector2(1f, 0f), enemySeaplane), new EnemyPos(new Vector2(2f, 0f), enemySeaplane),
                                new EnemyPos(new Vector2(3f, 0f), enemySeaplane), new EnemyPos(new Vector2(4f, 0f), enemySeaplane) });
    }

    private EnemyPos[] Escort()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(1f, 0f), torpedoBomber), new EnemyPos(new Vector2(0f, .5f), enemySeaplane), new EnemyPos(new Vector2(0f, -.5f), enemySeaplane) });
    }

    private EnemyPos[] Diamand()
    {
        return (new EnemyPos[] { new EnemyPos(new Vector2(0f, 0f), enemySeaplane), new EnemyPos(new Vector2(1f, 1f), enemySeaplane), new EnemyPos(new Vector2(1f, -1f), enemySeaplane),
                                new EnemyPos(new Vector2(2f, 0f), enemySeaplane), new EnemyPos(new Vector2(1f, 0f), torpedoBomber)});
    }
}