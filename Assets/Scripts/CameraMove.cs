using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public List<Vector3> CameraLocations;
    public GameObject mainCamera;
    public GameObject playerObject;
    
    void Update()
    {
        var playerPos = playerObject.transform.position;
        // Farm area
        if(playerPos.z > -16 && playerPos.x > -8 ){
            mainCamera.transform.position = CameraLocations[0];
        } 
        // Pond Area
        else if(playerPos.z > -16 && playerPos.x < -8){
            mainCamera.transform.position = CameraLocations[1];
        }
        // Forest Area
        else if(playerPos.z < -16 && playerPos.x >= -8){
            mainCamera.transform.position = CameraLocations[2];
        }

        // Forest Spirit Area
        else{
             mainCamera.transform.position = CameraLocations[3];
        }
    }
}
