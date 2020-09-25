using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropField : MonoBehaviour
{
    CropCard crop=null;
    int growth = 1;
    int yieldModifier = 0;
    List<StatusEffect> statusEffects = new List<StatusEffect>();

    internal void ClearCrop()
    {
        statusEffects.Clear();
        AddStatusEffect(crop.HarvestedSoil());
        crop = null;

    }

    public void SetCrop(CropCard crop) {
        //You can't plant a new crop if you already have a crop do you?
        if (this.crop != null) { 
            this.crop = crop;
            growth = crop.GrowthTime;
            yieldModifier = 0;
            foreach (var effect in statusEffects)
            {
                effect.OnNewCrop(this, crop);
            }
        }
    }

    int GetYield() { 
        //combining the crop's yield with it's modifier, with a minimum of 0 to prevent getting negative yield.
        //Optionally change 0 to 1 to make sure you get at least 1 yield every time.
        return System.Math.Max(crop.Yield+yieldModifier,0);
    }
    public void AddYield(int yield, StatusEffect modifier) {
        //adding to the yield's modifier (usually from status effects like fertilizer, sunny day, etc..)
        //Everything that is added is filtered through protecting status effects.
        int finalResult = yield; // Adding a middle variable instead of using the one provided by the argument
        foreach (var effect in statusEffects)
        {
            finalResult = effect.OnYieldModified(this, modifier, finalResult);
        }
        yieldModifier += finalResult;
    }
    public void AddGrowth(int growth, StatusEffect modifier) {
        //adding to the growth's modifier (usually from status effects like farm hand, etc..)
        //Everything that is added is filtered through protecting status effects.

        int finalResult = growth; // Adding a middle variable instead of using the one provided by the argument
       foreach (var effect in statusEffects)
        {
            finalResult = effect.OnGrowthModified(this, modifier, finalResult);
        }
        this.growth += finalResult;
        this.growth = System.Math.Max(0, this.growth);//You can't harvest a crop from the past, a growth cannot be negative.
    }


    public int EndTurn() {
        if (crop == null) return 0;
        //Executing end of turn effects
        foreach (var effect in statusEffects)
        {
            effect.Turns--;
            effect.OnEndTurn(this);
        }
        statusEffects.RemoveAll(effect => effect.Turns <= 0);// removing any effects that shouldn't be active anymore.


        //Growing the crop and "harvesting" if it's ready
        growth--;
        if (growth <= 0) {
            int finalYield = GetYield();
            ClearCrop(); 
            return finalYield*crop.YieldValue;
        }
        return 0;
    }

    public void AddStatusEffect(StatusEffect statusEffect) {
        statusEffects.Add(statusEffect);
        statusEffect.OnApply(this);
    }





}
