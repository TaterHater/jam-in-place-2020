using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //private static BaseItem filler = new EmptyItem();

    int yield =0;
    [SerializeField]
    GameObject yieldText=null;
    public Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();


    public int Yield { get => yield; set { yield = value; if(yieldText!=null) yieldText.GetComponent<UnityEngine.UI.Text>().text = value.ToString(); } }

    void Start()
    {
        items.Add(ItemType.Seeds,1);
        items.Add(ItemType.WaterThingy, 0);
        items.Add(ItemType.Fish, 0);
        items.Add(ItemType.Butterfly, 0);
        
    }

 
    public void Use(ItemType item) {
        items[item] = Math.Max(items[item] - 1, 0);
    }
    public void GainItem(ItemType item)
    {
        items[item]++;
    }

    public bool Have(ItemType item) {
        return items[item] > 0;
    }
   

   
    

    bool BuyItem(ItemType item,int amount)
    {
        if (amount>Yield) return false;
        GainItem(item);
        Yield -= amount;
        return true;
    }

  

  


    public enum ItemType
    {
        Seeds = 0, WaterThingy = 1, Fish = 2, Butterfly = 3
    }
}

