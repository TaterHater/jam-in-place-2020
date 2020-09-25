using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    List<CropField> fields = new List<CropField>();
    Weather weatherSystem = new Weather();
    DeckAndHand dah = new DeckAndHand();
    int money = 0;

    void endTurn() {
        StatusEffect todaysWeather = weatherSystem.NextDay();
        foreach (CropField field in fields) {
            money+=field.EndTurn();
            field.AddStatusEffect(todaysWeather);
        }
    }
}
