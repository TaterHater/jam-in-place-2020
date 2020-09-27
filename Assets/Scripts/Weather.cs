using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather
{
    public Season season = Season.Spring;
    int day = 1;
    private float fChanceOfDifferentWeather = 0.2f;
    [SerializeField]
    int DaysPerSeason = 4;
    StatusEffect justAnotherDay = new JustAnotherDay();
    // a temporary way to store season related weather. includes pests and such so you wouldn't get both bad weather and pests
    StatusEffect[][] effects = new StatusEffect[][] {
        new StatusEffect[]{new SunnyDay(),new Pests()} , //Spring weather
        new StatusEffect[]{new Drought(), new Pests() } , //Summer weather
        new StatusEffect[]{new Rain()} , //Autumn weather
        new StatusEffect[]{new Blizzard()}   //Winter weather
    };

    public StatusEffect NextDay() {
        if (day >= DaysPerSeason)
        {
            int s = (int)season;
            s = (s + 1) % 4; // This adds 1 to the season value and then if it's >4 it will return to 0
            season = (Season)s;
            day = 0;
        }
        day++;

        return GetWeather();
    }

     StatusEffect GetWeather() {
        float fRand = Random.Range(0.0f, 1.0f);
        if (fRand <= fChanceOfDifferentWeather){
            StatusEffect[] seasonalEffects = effects[(int)season];
            return seasonalEffects[Random.Range(0, seasonalEffects.Length)];
        }
        return justAnotherDay;
    }



    public enum Season {
    Spring=0, Summer=1, Autumn=2, Winter=3
    }
}
