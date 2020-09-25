using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CropCard : Card
{
    [SerializeField]
    int growthTime = 2;

    [SerializeField]
    int yield = 50;
    
    [SerializeField]
    int yieldValue = 1;

    [SerializeField]
    Type cropType;
    readonly StatusEffect[] SoilEffects=new StatusEffect[] { new WheatSoil(), new TomatoSoil(), new CornSoil(), new PotatoSoil(), new PumpkinSoil(), new SquashSoil()};

    public StatusEffect HarvestedSoil() { return SoilEffects[(int)CropType]; }

    public int Yield { get => yield; set => yield = value; }
    public int GrowthTime { get => growthTime; set => growthTime = value; }
    public int YieldValue { get => yieldValue; set => yieldValue = value; }
    public Type CropType { get => cropType; set => cropType = value; }

    public override void Play(CropField field)
    {
        field.SetCrop(this);
    }

    public enum Type { 
    Wheat=0,Tomato=1,Corn=2,Potato=3,Pumpkin=4,Squash=5
    }

    class WheatSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

    class TomatoSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

    class CornSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

     
        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

    class PotatoSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

    class PumpkinSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

    class SquashSoil : StatusEffect
    {
        public override Type GetStatusType()
        {
            return Type.Soil;
        }

        public override void OnNewCrop(CropField field, CropCard crop)
        {
            base.OnNewCrop(field, crop);
        }

    }

}
