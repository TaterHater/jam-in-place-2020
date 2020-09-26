using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : BaseItem
{
    Crop.Type type = Crop.Type.Wheat;

    public override ItemType GetItemType()
    {
        return ItemType.Seeds;
    }

    public override bool IsConsumable()
    {
        return true;
    }

    public override object Use()
    {
        switch (type)
        {//todo fill these
            case Crop.Type.Wheat:
                break;
            case Crop.Type.Tomato:
                break;
            case Crop.Type.Corn:
                break;
            case Crop.Type.Potato:
                break;
            case Crop.Type.Pumpkin:
                break;
            case Crop.Type.Squash:
                break;
        }
        Crop c = new Crop();
        //c.state = Crop.State.Mature; 
        return c;
    }
}
