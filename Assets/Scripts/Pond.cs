using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : InteractableObject
{
    [SerializeField]
    float chanceToGetAFish=0.1f;
    public override void Interact(PlayerScript ps)
    {
        ps.inventory.GainItem(Inventory.ItemType.WaterThingy);
        if (Random.Range(0,1) <chanceToGetAFish) {
            ps.inventory.GainItem(Inventory.ItemType.Fish);
        }
    }
}
