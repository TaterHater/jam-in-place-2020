using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    float dayTimer = 0;
    [SerializeField]
    float secondsPerDay=120;
    Weather weather = new Weather();
    void Update()
    {
        dayTimer += Time.deltaTime;
        if (dayTimer > secondsPerDay) {
            weather.NextDay(); //possible to get the goodies here.
            dayTimer = 0;
            EventManager.TriggerEvent("new-day");

        }
        if (weather.season == Weather.Season.Winter) {
            EventManager.TriggerEvent("winter");
        }
    }
}
