 using UnityEngine;
 using System.Collections;
using System;

public class targetmove : MonoBehaviour
 {
     Vector3 newPosition;
    InteractableObject interactableObj = null;
    
     void Start () {
         newPosition = transform.position;
     }
     void Update()
     {
         if (Input.GetMouseButtonDown(1))
         {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit))
             {
                 newPosition = hit.point;
                 newPosition.y = -0.442f;
                interactableObj = hit.collider.gameObject.GetComponent<InteractableObject>();
             }
         }
     }
     public Vector3 GetPosition(){
         return newPosition;
     }

    internal void Interact(PlayerScript ps)
    {
        if (interactableObj != null) {
            interactableObj.Interact(ps);
            interactableObj = null;
        }
    }
}