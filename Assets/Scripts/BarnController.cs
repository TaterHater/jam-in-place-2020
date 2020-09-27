using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarnController : InteractableObject
{
    public GameObject menu;
    public Text message;
    [SerializeField]
    string messageText;
    PlayerScript player;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnMouseEnter()
    {
        message.text = messageText;
    }
    
    void OnMouseExit()
    {
        message.text = null;
    }
    public override void Interact(PlayerScript ps){
        player = ps;
        menu.SetActive(true);
    }
    public void CloseMenu(){
        menu.SetActive(false);
    }
    public void AddSeeds(){
        player.inventory.GainItem(Inventory.ItemType.Seeds,10);
    }
}
