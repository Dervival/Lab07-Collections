using System;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Card
    {
        public Enum CardSuit { get; set; }
        public Enum CardRank { get; set; }
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
    }
}
