using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit.Example;
using SensorToolkit;

public class PlayerScript : MonoBehaviour
{   


    public CharacterControls pc;
    public targetmove target;
    public SteeringRig SteerSensor;
    public Inventory inventory;
    public PlayerState playerStates;
    public List<GameObject> ignorableObsticles;
    void Update()
    {
        SteerSensor.IgnoreList = ignorableObsticles;

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

        Debug.Log(target);
    }
}
