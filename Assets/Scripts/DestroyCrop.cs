using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pest")
        {
            Destroy(gameObject);
        }

    }
}
