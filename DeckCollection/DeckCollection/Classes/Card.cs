using System;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Card
    {
        public Suit CardSuit { get; set; }
        public void SetSuit(Suit suit)
        {
            CardSuit = suit;
        }
        public Suit GetSuit()
        {
            return CardSuit;
        } 
        public Rank CardRank { get; set; }
        public void SetRank(Rank rank)
        {
            CardRank = rank;
        }
        public Rank GetRank()
        {
            return CardRank;
        }

        public Card(Rank cardRank, Suit cardSuit)
        {
            CardRank = cardRank;
            CardSuit = cardSuit;
        }

        public enum Suit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        };

        public enum Rank
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        };

        public bool Equals(Card a, Card b)
        {
            if(a.GetRank() == b.GetRank() && a.GetSuit() == b.GetSuit())
            {
                return true;
            }
            return false;
        }
    }
}
