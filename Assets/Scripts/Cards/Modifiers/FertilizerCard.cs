using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerCard : ModifierCard
{
 
    public override StatusEffect GetStatusEffect()
    {
        return new FertilizerStatusEffect();
    }
    class FertilizerStatusEffect : StatusEffect {
        public override Type GetStatusType()
        {
            return Type.Fertilized;
        }
        public override void OnApply(CropField field)
        {
            field.AddYield(2, this);
        }
    }
}
