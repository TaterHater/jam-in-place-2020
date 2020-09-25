using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckAndHand : MonoBehaviour
{
    List<Card> Deck = new List<Card>();
    List<Card> Hand = new List<Card>();


    void DrawCard() {
        if (Deck.Count > 0) {
            Hand.Add(Deck[0]);
            Deck.RemoveAt(0);
        }
    }

    void AddCard(Card c) {
        Deck.Add(c);
    }

    void PlayCard(Card card) {
        Hand.Remove(card);
        //Optional apply the card.play() here if you can get the field
    }
}
