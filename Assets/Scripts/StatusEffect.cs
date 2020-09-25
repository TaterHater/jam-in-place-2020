using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{

    public abstract Type GetStatusType();

    virtual public int Turns { get; set; }


    //used on a crop field to (you guessed it) apply the status effect's effect, usually through "addYield/addGrowth" 
    public virtual void OnApply(CropField field) { }

    //Whenever a turn ends you could override this function to add additional effects to the end of the turn
    public virtual void OnEndTurn(CropField field) { }

    //Upon changing the yield modifier in a crop field, this function is executed and can return any new modification to be used instead
    public virtual int OnYieldModified(CropField field, StatusEffect modifier, int amount) { return amount; }

    //Upon changing the growth modifier in a crop field, this function is executed and can return any new modification to be used instead
    public virtual int OnGrowthModified(CropField field, StatusEffect modifier, int amount) { return amount; }

    //When you add a new crop
    public virtual void OnNewCrop(CropField field, Crop crop) { }



    public enum Type{ 
    Weather, Pests,Fertilized,ExtraHand,Tarp, PestProof,Soil
    }
}
