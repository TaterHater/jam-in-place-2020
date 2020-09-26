using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem 
{
    public abstract ItemType GetItemType();
    public abstract bool IsConsumable();
          public enum ItemType{
        Seeds, Nothing,WaterThingy
    }

    public abstract object Use();
}
public class EmptyItem : BaseItem
{
    public override ItemType GetItemType()
    {
        return ItemType.Nothing;
    }

    public override bool IsConsumable()
    {
        return false;
    }

    public override object Use()
    {
        return null;
    }
}