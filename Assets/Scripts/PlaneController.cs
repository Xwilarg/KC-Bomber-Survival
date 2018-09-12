using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private const float speed = 10f;
    private Camera cam;
    [SerializeField]
    private GameObject bulletPrefab;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space)) ;
    }
}
