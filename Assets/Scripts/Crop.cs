using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Crop
{
    internal State state = State.Seed;
    [SerializeField]
    int age = 0;
    [SerializeField]
    int seedGrowthTime = 1;
    [SerializeField]
    int prematureGrowthTime = 1;

    internal void OnHarvest(CropField cropField)
    {
        //add to the field a bonus yield status effect if you'd like to do so
    }

    [SerializeField]
    int yield = 50;
    [SerializeField]
    int yieldValue = 1;
    [SerializeField]
    Type cropType;
    [SerializeField]
    int WaterlessDaysSurvivablity=2;
    int daysWithoutWater = 0;

    public enum Type { 
    Wheat=0,Tomato=1,Corn=2,Potato=3,Pumpkin=4,Squash=5
    }
    public enum State
    {
        Seed = 0,
        Premature=1,
        Mature=2,
        Dead=3,
        Empty=4
    }

    internal void AddAge(int finalResult)
    {
        this.Age = System.Math.Max(0, this.Age + finalResult);
    }

    internal void EndDay()
    {
        Age++;
        if (daysWithoutWater >= WaterlessDaysSurvivablity) state = State.Dead;
        daysWithoutWater++;
    }

    internal bool IsHarvestable() {
        return (state == State.Mature || state == State.Dead);
    }

    public int Yield { get => yield; set => yield = value; }
    public int YieldValue { get => yieldValue; set => yieldValue = value; }
    public Type CropType { get => cropType; set => cropType = value; }
    public int Age { get => age; 
        set { 
            age = value;
            int nextAge = seedGrowthTime;
            if (age >= nextAge && state == State.Seed) { state = State.Premature; }
            nextAge += prematureGrowthTime;
             if (age >= nextAge && state == State.Premature) { state = State.Mature; }
        }
    }

    internal void Water()
    {
        daysWithoutWater = 0;
    }
}
