using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysThatDoStuff : MonoBehaviour
{
    // Start is called before the first frame update
    CropField cf;
    void Start()
    {
        Crop c = new Crop();
         cf = GetComponent<CropField>();
         cf.SetCrop(c);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cf.EndDay();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            cf.Water();
        } 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(cf.Harvest());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(cf.ToString());
        }



    }
}
