using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyDay : StatusEffect
{
    public override Type GetStatusType()
    {
        return Type.Weather;
    }

    public override void OnApply(CropField field)
    {
        field.AddGrowth(2, this);
    }
}
