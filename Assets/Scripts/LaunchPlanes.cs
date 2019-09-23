using UnityEngine;

public class LaunchPlanes : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fighters;
    [SerializeField]
    private GameObject bomber;

    private float[] timers;
    private bool startLaunching;

    private void Start()
    {
        timers = new[] {
            .5f, 1f, 1.5f, 2f
        };
        startLaunching = false;
    }

    private void Update()
    {
        if (!startLaunching)
            return;
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;
            if (timers[i] < 0f && timers[i] > -1f)
            {
                if (i == timers.Length - 1)
                {
                    SpawnGameObject(bomber);
                    enabled = false;
                }
                else
                    SpawnGameObject(fighters[i]);
                timers[i] = -2f;
            }
        }
    }

    private void SpawnGameObject(GameObject go)
    {
        go.transform.position = transform.position;
        go.SetActive(true);
    }

    public void Launch()
    {
        startLaunching = true;
    }
}
