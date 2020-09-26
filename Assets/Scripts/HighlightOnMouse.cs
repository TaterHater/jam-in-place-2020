using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnMouse : MonoBehaviour
{
    private Color startcolor;
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.GetColor("_BaseColor");
        Color highlight = new Color(startcolor.r*2,startcolor.g*2,startcolor.b*2,startcolor.a);
        GetComponent<Renderer>().material.SetColor("_BaseColor", highlight);
        
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", startcolor);
    }

}
