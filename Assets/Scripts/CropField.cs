﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropField : MonoBehaviour
{
    Crop crop=null;
    int yieldModifier = 0;
    List<StatusEffect> statusEffects = new List<StatusEffect>();
    internal void ClearCrop()
    {
        statusEffects.Clear();
        crop.OnHarvest(this);
        crop = null;

    }

    public void SetCrop(Crop crop) {
        //You can't plant a new crop if you already have a crop do you?
        if (this.crop == null) { 
            this.crop = crop;
            yieldModifier = 0;
            foreach (var effect in statusEffects)
            {
                effect.OnNewCrop(this, crop);
            }
        } 
    }

    int GetYield() {
        if (crop.state == Crop.State.Dead) return 0;
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
        crop.AddAge(finalResult);
    }


    public void EndDay() {
        if (crop == null) return;
        //Executing end of turn effects
        foreach (var effect in statusEffects)
        {
            effect.Turns--;
            effect.OnEndTurn(this);
        }
        statusEffects.RemoveAll(effect => effect.Turns <= 0);// removing any effects that shouldn't be active anymore.
        crop.EndDay();
    }

    public void AddStatusEffect(StatusEffect statusEffect) {
        statusEffects.Add(statusEffect);
        statusEffect.OnApply(this);
    }

    public int Harvest() {
        if (crop != null && crop.Harvestable()) {
            int yield = GetYield();
            ClearCrop();
            return yield;
        }
        return 0;
    } 
    
    public bool Harvestable() {
        return (crop != null && crop.Harvestable());
    }

    public void Water() {
        if (crop != null) crop.Water();
    }


    public override string ToString()
    {
        return crop.state.ToString()+ " " + crop.Age+ " ";
    }


}
