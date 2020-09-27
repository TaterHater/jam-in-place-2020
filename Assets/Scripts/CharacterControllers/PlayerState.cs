using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerState : MonoBehaviour
{
    public State state = State.Moving;
    float stateTimer = 0;
    [SerializeField]
    float timeToWater = 2;
    [SerializeField]
    float timeToPlant = 1;
    [SerializeField]
    float timeToHarvest = 2;
    [SerializeField]
    float timeToFish = 4;
    public Slider timer;

    public bool CanMove()
    {
        return state == State.Moving;
    }

    void Update()
    {
        timer.value = stateTimer;
        if (stateTimer > 0)
        {

            stateTimer -= Time.deltaTime;

        }
        else state = State.Moving;
    }

    public void StartWatering()
    {
        state = State.Watering;
        stateTimer = timeToWater;
        timer.maxValue = timeToWater;
        timer.value = timeToWater;
    }
    public void StartPlanting()
    {
        state = State.Planting;
        stateTimer = timeToPlant;
        timer.maxValue = timeToPlant;
        timer.value = timeToPlant;
    }
    public void StartHarvesting()
    {
        state = State.Harvesting;
        stateTimer = timeToHarvest;
        timer.maxValue = timeToHarvest;
        timer.value = timeToHarvest;
    }
    public void StartFishing()
    {
        state = State.Fishing;
        stateTimer = timeToFish;
        timer.maxValue = timeToFish;
        timer.value = timeToFish;
    }

    public enum State
    {
        Watering, Planting, Harvesting, Moving, Fishing
    }
}
