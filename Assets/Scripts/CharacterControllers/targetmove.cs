﻿using UnityEngine;
using System.Collections;
using System;

public class targetmove : MonoBehaviour
{
    Vector3 newPosition;
    InteractableObject interactableObj = null;

    void Start()
    {
        newPosition = transform.position;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.Log(newPosition.x + " " + newPosition.y);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                newPosition.y = -0.358f;

                interactableObj = hit.collider.gameObject.GetComponent<InteractableObject>();
            }
        }
    }
    public Vector3 GetPosition()
    {
        return newPosition;
    }

    internal void Interact(PlayerScript ps)
    {
        if (interactableObj != null)
        {
            interactableObj.Interact(ps);
            interactableObj = null;
        }
    }
}