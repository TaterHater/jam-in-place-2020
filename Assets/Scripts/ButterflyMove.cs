using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{


    [SerializeField] public float moveSpeed;
    public GameObject player;
    private float movementThisFrame;

    [SerializeField] List<GameObject> waypoints;
    [SerializeField] public float timeToWaitBeforeMoving;
    public bool isMoving;
    public float currentTime;
    int waypointIndex = 0;
    Vector3 targetPosition;
    private Rigidbody butterflyRb;

  


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(currentTime >= timeToWaitBeforeMoving)
        {
            isMoving = true;
            currentTime = timeToWaitBeforeMoving + 1f;
        }

        if(currentTime < timeToWaitBeforeMoving)
        {
            isMoving = false;
            currentTime = currentTime + Time.deltaTime;
        }

        /*
            currentTime = currentTime + Time.deltaTime;
            Countdown timer < timeToWaitBeforeMoving: 

        */
    }

    public void Move()
    {

        // if (timer has successfully counted down)
        if (isMoving == true)
        {
            // The butterfly uses a list of gameObjects called "Waypoints, to move towards the next Waypoint's transform.position. The Waypoins are assigned in the Inspector. 

            if (waypointIndex <= waypoints.Count - 1)
            {
                targetPosition = waypoints[waypointIndex].transform.position;
                movementThisFrame = moveSpeed * Time.deltaTime;
                //    Vector2 enemyTarget = targetPosition - transform.position;           
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }

            else if (waypointIndex == waypoints.Count)
            {
                //   ropeSystem.ResetRope();
                //      wormShipPrefab.SetActive(false);
                waypointIndex = 0;
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Destroy(gameObject);

        }
    }
}
