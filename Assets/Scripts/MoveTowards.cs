using UnityEngine;
using UnityEngine.Events;

public class MoveTowards : MonoBehaviour
{
    [SerializeField]
    private Vector2 target;
    [SerializeField]
    private float timeBeforeStart;
    [SerializeField]
    private UnityEvent onComplete;
    [SerializeField]
    private bool lockX, lockY;
    [SerializeField]
    private float speed;
    private float closeEnough;

    private void Start()
    {
        closeEnough = speed * 0.1f;
    }

    private void Update()
    {
        if (timeBeforeStart > 0f)
        {
            timeBeforeStart -= Time.deltaTime;
            return;
        }
        float x = transform.position.x - target.x;
        float y = transform.position.y - target.y;
        int newX = 0, newY = 0;

        if (!lockX)
        {
            if (x > closeEnough) newX = -1;
            else if (x < -closeEnough) newX = 1;
        }

        if (!lockY)
        {
            if (y > closeEnough) newY = -1;
            else if (y < -closeEnough) newY = 1;
        }

        if (newX == 0 && newY == 0)
        {
            var cc = GetComponent<PlaneController>();
            if (cc != null)
                cc.enabled = true;
            else
            {
                onComplete.Invoke();
                GetComponent<MoveTowards>().enabled = false;
            }
            enabled = false;
        }

        transform.Translate(new Vector2(newX, newY) * speed * Time.deltaTime);
    }
}
