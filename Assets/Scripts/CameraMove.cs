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
        //farm area
        if(playerPos.z > -14 && playerPos.x > -10 ){
            mainCamera.transform.position = CameraLocations[0];
        } 
        //Pond Area
        else if(playerPos.z > -14 && playerPos.x < -10){
            mainCamera.transform.position = CameraLocations[1];
        }
        //forest Area
        else if(playerPos.z < -14 && playerPos.x >= -5){
            mainCamera.transform.position = CameraLocations[2];
        }
        else{
             mainCamera.transform.position = CameraLocations[3];
        }
    }
}
