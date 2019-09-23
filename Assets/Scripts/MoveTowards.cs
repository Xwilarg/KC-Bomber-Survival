using UnityEngine;
using UnityEngine.Events;

public class MoveTowards : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Don't change this variable if the next one is not null")]
    private Vector2 target;
    [SerializeField]
    private Transform targetGo;
    [SerializeField]
    private float timeBeforeStart;
    [SerializeField]
    private UnityEvent onComplete;
    [SerializeField]
    private bool lockX, lockY;
    [SerializeField]
    private float speed;
    bool isBeforeX, isBeforeY; // If the element is before or after it destination on the X and Y axis

    private void OnValidate()
    {
        if (targetGo != null)
            target = targetGo.position;
    }

    private void Start()
    {
        OnValidate();
        isBeforeX = transform.position.x - target.x < 0f;
        isBeforeY = transform.position.y - target.y < 0f;
    }

    private void Update()
    {
        if (timeBeforeStart > 0f)
        {
            timeBeforeStart -= Time.deltaTime;
            return;
        }
        int newX = 0, newY = 0;

        if (!lockX)
        {
            if (isBeforeX) newX = 1;
            else newX = -1;
        }

        if (!lockY)
        {
            if (isBeforeY) newY = 1;
            else newY = -1;
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

        Vector3 newPos = transform.position + new Vector3(newX, newY) * speed * Time.deltaTime;
        if ((isBeforeX && newPos.x > target.x) || (!isBeforeX && newPos.x < target.x))
            newPos = new Vector3(target.x, newPos.y, 0f);
        if ((isBeforeY && newPos.y > target.y) || (!isBeforeY && newPos.y < target.y))
            newPos = new Vector3(newPos.x, target.y, 0f);
        transform.position = newPos;
    }
}
