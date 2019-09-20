using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField]
    private Vector2 target;
    private const float speed = 2f;
    private const float closeEnough = 0.05f;

    private void Update()
    {
        float x = transform.position.x - target.x;
        float y = transform.position.y - target.y;
        int newX = 0, newY = 0;

        if (x > closeEnough) newX = -1;
        else if (x < -closeEnough) newX = 1;

        if (y > closeEnough) newY = -1;
        else if (y < -closeEnough) newY = 1;

        if (newX == 0 && newY == 0)
        {
            var cc = GetComponent<PlaneController>();
            if (cc != null)
                cc.enabled = true;
            else
            {
                GetComponent<EscortController>().enabled = true;
            }
            enabled = false;
        }

        transform.Translate(new Vector2(newX, newY) * speed * Time.deltaTime);
    }
}
