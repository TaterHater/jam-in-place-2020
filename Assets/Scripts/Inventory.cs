using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static BaseItem filler = new EmptyItem();

    int yield =0;
    [SerializeField]
    int capacity = 9;
    [SerializeField]
    GameObject yieldText=null;
    public List<BaseItem> items;
    private int activeItemIndex = 0;

    public int Yield { get => yield; set { yield = value; if(yieldText!=null) yieldText.GetComponent<UnityEngine.UI.Text>().text = value.ToString(); } }

    void Start()
    {
        items = new List<BaseItem>(capacity);
        for (int i = 0; i < capacity; i++){
            items.Add(new Seeds());
        }
    }

 
    public object Use(BaseItem item) {
        object useResult = item.Use();
        if(item.IsConsumable())
            items[items.IndexOf(item)] = filler;
        return useResult;
    }
    public object UseActiveItem()
    {
        return Use(GetActiveItem());
    }

    bool GainItem(BaseItem item)
    {
        if (items.Count >= capacity) return false;
        items.Add(item);
        return true;
    }
    

    bool BuyItem(BaseItem item,int amount)
    {
        if (items.Count >= capacity || amount>Yield) return false;
        items.Add(item);
        Yield -= amount;
        return true;
    }

  

    public BaseItem GetActiveItem()
    {
        return items[activeItemIndex];
    }
}

