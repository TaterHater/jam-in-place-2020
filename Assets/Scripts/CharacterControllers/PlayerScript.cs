using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit.Example;
using SensorToolkit;

public class PlayerScript : MonoBehaviour
{

    public float butterflyCount;

    void Start()
    {
        butterflyCount = 0f;
    }


    public CharacterControls pc;
    public targetmove target;
    public SteeringRig SteerSensor;
    public Inventory inventory;
    public PlayerState playerStates;
    void Update()
    {

        if (playerStates.CanMove())
        {
            if (Vector3.Distance(transform.position, target.GetPosition()) > 0.1f)
            {
                var targetDirection = SteerSensor.GetSteeredDirection((target.GetPosition() - this.gameObject.transform.position).normalized);
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.GetComponent<Rigidbody>().freezeRotation = false;
                pc.Move = targetDirection;
                pc.Face = pc.Move;
            }
            else
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<Rigidbody>().freezeRotation = true;
                target.Interact(this);
            }
        }

    }
}
