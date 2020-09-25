using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : StatusEffect
{
    public override Type GetStatusType()
    {
        return Type.Weather;
    }

    public override void OnApply(CropField field)
    {
        field.ClearCrop();
    }
}
