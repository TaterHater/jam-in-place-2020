using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestMove : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    private float movementThisFrame;

    public Vector3 directionChange;
    public Vector3 finalDestination;

    [SerializeField] public float timeInChangedDirection;

    public float directionChangeFrequency;
    public float directionChangeFrequencyCounter;
    public bool targetAcquired;
    public float timeInNewDirection;
    public float timeCounter;


    // Uses Vector3.MoveTowards(finalDirection) for a certain amount of time (directionChangeFrequency

    // Start is called before the first frame update
    void Start()
    {
        targetAcquired = true;
        directionChangeFrequencyCounter = 0f;
        directionChangeFrequency = 3f;
        timeCounter = 0f;
        timeInChangedDirection = 2f;
        //  directionChange = transform.position + new Vector3(Random.Range(-1f, 2f), 0f, 0f); 
        directionChange = finalDestination + new Vector3(Random.Range(-10f, 10f), 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {        

        directionChangeFrequencyCounter = directionChangeFrequencyCounter + Time.deltaTime;
        movementThisFrame = moveSpeed * Time.deltaTime;

        if (targetAcquired == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalDestination, movementThisFrame);
        }
        
        if(directionChangeFrequencyCounter >= directionChangeFrequency)
        {
            targetAcquired = false;
            transform.position = Vector3.MoveTowards(transform.position, directionChange, movementThisFrame);
            timeCounter = timeCounter + Time.deltaTime;
            if(timeCounter >= timeInChangedDirection)
            {
                targetAcquired = true;
                timeCounter = 0f;
                directionChangeFrequencyCounter = 0f;
                timeInChangedDirection = 2f;
                directionChangeFrequency = 3f;
                directionChange = finalDestination + new Vector3(Random.Range(-10f, 10f), 0f, 0f);
            }                   
           
        } 
    }    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "pestDest")
        {

            Destroy(gameObject);
        }
    }
}
