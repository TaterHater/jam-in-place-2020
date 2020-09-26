using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingCube : MonoBehaviour
{
    [SerializeField]
    GameObject fieldObject=null;
    CropField field;
    Crop.State state = Crop.State.Empty;

    void Start(){
        if (fieldObject == null)
        {
            Debug.LogError("Please set up a field");
        }
        else {
            field = fieldObject.GetComponent<CropField>();
        }
    }

    void Update() {
        state = field.GetState();
        for (int i = 0; i < 5/*Amount of states*/; i++)
        {
            transform.GetChild(i).gameObject.SetActive(((int)state) ==i);
        }


    }
}
