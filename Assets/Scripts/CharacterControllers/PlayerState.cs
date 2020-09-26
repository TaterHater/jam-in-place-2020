using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public bool CanMove() {
        return state == State.Moving;
    }

    void Update()
    {
        if (stateTimer > 0)
        {
            stateTimer -= Time.deltaTime;

        }
        else state = State.Moving;
    }

    public void StartWatering() {
        state = State.Watering;
        stateTimer = timeToWater;
    }
    public void StartPlanting() {
        state = State.Planting;
        stateTimer = timeToPlant;
    }
    public void StartHarvesting() {
        state = State.Harvesting;
        stateTimer = timeToHarvest;
    }

    public enum State {
    Watering, Planting, Harvesting, Moving
    }
}
