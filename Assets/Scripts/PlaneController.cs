using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneController : MonoBehaviour
{
    // Main: Type 97 aircraft machine guns
    // Sub: Type 99-1 cannon
    private const float speed = 500f;
    private const float mainBulletSpeed = 15f;
    private const float subBulletSpeed = 20f;
    private Camera cam;
    private int health;
    private int nbEscort;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Text mainGunText, subGun1Text, subGun2Text, escortText, healthText;
    private int mainGunMun, subGunMun;

    private const float refFireRateMain = .007f; // 900 rounds per minute
    private float fireRateSub;
    private const float refFireRateSub = .015f; // 520 rounds per minutes
    private float fireRateMain;

    private Rigidbody2D rb;
    private Vector2 vel;

    private const int refillHealthAmount = 30, refillMainAmount = 200, refillSubAmount = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        healthText.text = health + "%";
    }

    public void DamageEscort()
    {
        nbEscort--;
        escortText.text = nbEscort.ToString();
    }

    public void RefillMain()
    {
        mainGunMun += refillMainAmount;
        if (mainGunMun > 500)
            mainGunMun = 500;
        mainGunText.text = mainGunMun.ToString();
    }

    public void RefillSub()
    {
        subGunMun += refillSubAmount;
        if (subGunMun > 60)
            subGunMun = 60;
        subGun1Text.text = subGunMun.ToString();
        subGun2Text.text = subGunMun.ToString();
    }

    public void RefillHealth()
    {
        health += refillHealthAmount;
        if (health > 100)
            health = 100;
        healthText.text = health + "%";
    }

    private void Start()
    {
        cam = Camera.main;
        fireRateMain = 0f;
        fireRateSub = 0f;
        mainGunMun = 500;
        subGunMun = 60;
        health = 100;
        nbEscort = 3;
        vel = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Delay between 2 shot
        fireRateMain -= Time.deltaTime;
        fireRateSub -= Time.deltaTime;

        // Controls for PC
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if (Input.GetKey(KeyCode.L))
            FireMain();
        if (Input.GetKey(KeyCode.M))
            FireSub();
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) / 1.5f); // TODO: Conflict with the move button on PC
#endif
        rb.velocity = vel;
        vel = Vector2.zero;
    }

    public void FireMain()
    {
        if (fireRateMain < 0f && mainGunMun > 0)
        {
            fireRateMain = refFireRateMain;
            mainGunMun--;
            Fire(new Vector2(.8f, .8f), mainBulletSpeed, Random.Range(-.1f, .1f));
            mainGunText.text = mainGunMun.ToString();
        }
    }

    public void FireSub()
    {
        if (fireRateSub < 0f && subGunMun > 0)
        {
            fireRateSub = refFireRateSub;
            subGunMun--;
            Fire(new Vector2(1f, 1f), subBulletSpeed, -.4f);
            Fire(new Vector2(1f, 1f), subBulletSpeed, .4f);
            subGun1Text.text = subGunMun.ToString();
            subGun2Text.text = subGunMun.ToString();
        }
    }

    public void Move(Vector2 pos)
    {
        vel = new Vector2(Mathf.Clamp(pos.x, -1f, 1f), Mathf.Clamp(pos.y, -1f, 1f)) * Time.deltaTime * speed;
    }

    private void Fire(Vector2 scale, float bulletSpeed, float yOffset)
    {
        GameObject go = Instantiate(bulletPrefab, transform.position + new Vector3(0f, yOffset, 0f), Quaternion.identity);
        go.transform.localScale = scale;
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0f), ForceMode2D.Impulse);
        Destroy(go, 2);
    }
}
