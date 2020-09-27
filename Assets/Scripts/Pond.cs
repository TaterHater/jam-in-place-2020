using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pond : InteractableObject
{
    public Text message;
    [SerializeField]
    string messageText;

    [SerializeField]
    float chanceToGetAFish = 0.1f;

    public override void Interact(PlayerScript ps)
    {
        if(chanceToGetAFish ==0)
        ps.inventory.GainItem(Inventory.ItemType.WaterThingy,5);
        if (Random.Range(0, 1) < chanceToGetAFish)
        {
            ps.playerStates.StartFishing();
            ps.inventory.GainItem(Inventory.ItemType.Fish);
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
