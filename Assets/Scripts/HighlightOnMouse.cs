using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightOnMouse : MonoBehaviour
{
    private Color startcolor;
    public Text message = null;
    [SerializeField]
    string messageText;
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.GetColor("_BaseColor");
        Color highlight = new Color(startcolor.r * 2, startcolor.g * 2, startcolor.b * 2, startcolor.a);
        GetComponent<Renderer>().material.SetColor("_BaseColor", highlight);
        var test = this.gameObject.GetComponent<CropField>().ToString();
        if (message)
            message.text = test;

    }
    void OnMouseExit()
    {
        if (message)
            message.text = null;
        GetComponent<Renderer>().material.SetColor("_BaseColor", startcolor);
    }

}
