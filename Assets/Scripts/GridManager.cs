using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public float x_Start, z_Start;

    public int numberOfColumns, numberOfRows;

    public float x_Space, z_Space, y_Space;
    public GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfColumns * numberOfRows; i++)
        {
            Instantiate(prefab, new Vector3(x_Start + (x_Space * (i % numberOfColumns)), y_Space, z_Start + (z_Space * (i / numberOfColumns))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
