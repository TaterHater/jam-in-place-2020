using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pests : StatusEffect
{
    public override int Turns { get => 5; }

    public override Type GetStatusType()
    {
        return Type.Pests;
    }
   

    public override void OnEndTurn(CropField field)
    {
        field.AddYield(-1, this);
    }


}
