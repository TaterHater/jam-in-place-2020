using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{

    [SerializeField] public GameObject pestPrefab;
    private float currentTime;
    public float timeToWaitBeforeSpawning;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if (currentTime >= timeToWaitBeforeSpawning)
        {
            Instantiate(pestPrefab, transform.position, transform.rotation);
            currentTime = 0f;
            timeToWaitBeforeSpawning = Random.Range(100f, 201f);
        }
    }
}
