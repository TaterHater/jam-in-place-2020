using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierCard : Card
{
    public override void Play(CropField field)
    {
        field.AddStatusEffect(GetStatusEffect());
    }

    public abstract StatusEffect GetStatusEffect();
}
