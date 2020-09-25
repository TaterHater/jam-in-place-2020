using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarpCard : ModifierCard
{
    public override StatusEffect GetStatusEffect()
    {
        return new TarpStatusEffect();
    }
    class TarpStatusEffect : StatusEffect {
        public override int Turns { get => 4; }

        public override Type GetStatusType()
        {
            return Type.Tarp;
        }
        public override int OnYieldModified(CropField field, StatusEffect modifier, int amount)
        {
            if (modifier.GetStatusType() == Type.Weather)
            {
                return amount/2;
            }
            else return base.OnYieldModified(field, modifier, amount);

        }

        public override int OnGrowthModified(CropField field, StatusEffect modifier, int amount)
        {
            if (modifier.GetStatusType() == Type.Weather)
            {
                return amount/2;
            }
            else return base.OnYieldModified(field, modifier, amount);

        }
    }
}
