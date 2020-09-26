 using UnityEngine;
 using System.Collections;
 public class targetmove : MonoBehaviour
 {
     Vector3 newPosition;
     void Start () {
         newPosition = transform.position;
     }
     void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit))
             {
                 newPosition = hit.point;
                 newPosition.y = -0.442f;
             }
         }
     }
     public Vector3 GetPosition(){
         return newPosition;
     }
 }