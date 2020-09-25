using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFarmHandCard : ModifierCard
{

    public override StatusEffect GetStatusEffect()
    {
        return new ExtraFarmHandStatusEffect();
    }
    class ExtraFarmHandStatusEffect : StatusEffect {
        public override Type GetStatusType()
        {
            return Type.ExtraHand;
        }

        public override void OnApply(CropField field) {
            field.AddGrowth(2, this);
        }

    }
}
