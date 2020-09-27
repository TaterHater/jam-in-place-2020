using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //private static BaseItem filler = new EmptyItem();

    int yield = 0;
    [SerializeField]
    GameObject yieldText = null;
    [SerializeField]
    Text WaterText;
    [SerializeField]
    Text SeedText;
    [SerializeField]
    Text FishText;
    [SerializeField]
    Text ButterflyText;
    public Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();


    public int Yield { get => yield; set { yield = value; if (yieldText != null) yieldText.GetComponent<UnityEngine.UI.Text>().text = value.ToString(); } }

    void Start()
    {
        items.Add(ItemType.Seeds, 1);
        items.Add(ItemType.WaterThingy, 1);
        items.Add(ItemType.Fish, 0);
        items.Add(ItemType.Butterfly, 0);

        WaterText.text = items[ItemType.WaterThingy].ToString();
        SeedText.text = items[ItemType.Seeds].ToString();
        FishText.text = items[ItemType.Fish].ToString();
        ButterflyText.text = items[ItemType.Butterfly].ToString();

    }


    public void Use(ItemType item)
    {
        items[item] = Math.Max(items[item] - 1, 0);
        UpdateText(item);
    }
    public void GainItem(ItemType item, int amount = 1)
    {
        items[item]+= amount;
        UpdateText(item);
    }

    public bool Have(ItemType item)
    {
        return items[item] > 0;
    }





    bool BuyItem(ItemType item, int amount)
    {
        if (amount > Yield) return false;
        GainItem(item);
        Yield -= amount;
        UpdateText(item);
        return true;
    }

    void UpdateText(ItemType item)
    {
        if (item == ItemType.Seeds)
        {
            SeedText.text = items[ItemType.Seeds].ToString();
        }
        if (item == ItemType.WaterThingy)
        {
            WaterText.text = items[ItemType.WaterThingy].ToString();
        }
        if (item == ItemType.Butterfly)
        {
            ButterflyText.text = items[ItemType.Butterfly].ToString();
        }
        if (item == ItemType.Fish)
        {
            FishText.text = items[ItemType.Fish].ToString();
        }

    }




    public enum ItemType
    {
        Seeds = 0, WaterThingy = 1, Fish = 2, Butterfly = 3
    }
}

