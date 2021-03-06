﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class godController : InteractableObject
{
    //interactable alter to offer goods
    // animate god object
    // randomize sacrificial requirements

    public Text message;
    public Text HeaderText;
    [SerializeField]
    string messageText;
    public int fishDemanded; //0
    public int cropDemanded; //1 
    public int bugsDemanded; //2
    public int butterflyCount;   

    public Vector3 StartPos;
    public Vector3 EndPos;
    public bool arrived;
    public float speed;
    public float step;
    public GameObject god;
    public GameObject donationArea;
    int[] inventory;


    void Start()
    {
     //   EventManager.StartListening("winter", Activate);
     //   EventManager.StartListening("spring", Deactivate);
        inventory = new int[3];
      //   this.gameObject.SetActive(false);
         HeaderText.text = "Gather "+cropDemanded+" crops, "+
         fishDemanded +" fish";        
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (arrived == true)
        {
            god.transform.position = Vector3.MoveTowards(god.transform.position, EndPos, step);
            Debug.Log("Bababooey");
        }

        else if (arrived == false)
        {
            god.transform.position = Vector3.MoveTowards(god.transform.position, StartPos, step);
            Debug.Log("Bazinga");
        }
    }

    /*  void Activate()
      {
       //   this.gameObject.SetActive(true);
          float step = speed * Time.deltaTime;
          god.transform.position = Vector3.MoveTowards(god.transform.position, EndPos, step);
      }
      */

    /* void Deactivate()
     {
         float step = speed * Time.deltaTime;
         god.transform.position = Vector3.MoveTowards(god.transform.position, StartPos, step);
      //   if(god.transform.position == StartPos){
         //     this.gameObject.SetActive(false);
       //  }
     } */
    public override void Interact(PlayerScript ps)
    {
        //TODO - actions handled by the alter object
        inventory[0] = ps.inventory.GetAmount(Inventory.ItemType.Fish);
        inventory[1] = ps.inventory.Yield;
        inventory[2] = ps.inventory.GetAmount(Inventory.ItemType.Butterfly);

        if (inventory[0] >= fishDemanded && inventory[1] >= cropDemanded && butterflyCount >= bugsDemanded)
        {
            //god takes everything needed
            ps.inventory.BuyItem(Inventory.ItemType.Seeds, cropDemanded);
            ps.inventory.Use(Inventory.ItemType.Fish, fishDemanded);
            ps.inventory.Use(Inventory.ItemType.Butterfly, bugsDemanded);
            butterflyCount = 0;
        }
        else
        {
            //status update says "not enough of stuff"
            message.text = "You do not have enough resources";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            arrived = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            arrived = false;           
        }
    } 
    void OnMouseEnter()
    {
        message.text = messageText;
    }
    void OnMouseExit()
    {
        message.text = null;
    }
}
