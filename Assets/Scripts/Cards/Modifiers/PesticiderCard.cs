using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesticiderCard : ModifierCard
{
    public override StatusEffect GetStatusEffect()
    {
        return new PesticiderStatusEffect();
    }
    class PesticiderStatusEffect : StatusEffect {
        public override int Turns { get => 5; }
        public override Type GetStatusType()
        {
            return Type.PestProof;
        }
        public override int OnYieldModified(CropField field, StatusEffect modifier, int amount) {
            if (modifier.GetStatusType() == Type.Pests) {
                return 0;
            }
            else return base.OnYieldModified(field, modifier, amount);
            
        }
    }
}
