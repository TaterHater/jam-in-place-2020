using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeasonManager : MonoBehaviour
{
    float dayTimer = 0;
    float daysElapsed = 0;
    [SerializeField]
    float secondsPerDay = 120;
    Weather weather = new Weather();
    public Text DayText; //Ahhh-AAA-ahhhh
    public Text SeasonText;
    void Update()
    {
        dayTimer += Time.deltaTime;
        if (dayTimer > secondsPerDay)
        {
            weather.NextDay(); //possible to get the goodies here.
            dayTimer = 0;
            EventManager.TriggerEvent("new-day");
            daysElapsed++;

        }
        if (weather.season == Weather.Season.Winter)
        {
            EventManager.TriggerEvent("winter");
        }
        if(weather.season == Weather.Season.Spring){
            EventManager.TriggerEvent("spring");
        }
        DayText.text = "Day " + daysElapsed;
        SeasonText.text = weather.season.ToString();
    }
}
