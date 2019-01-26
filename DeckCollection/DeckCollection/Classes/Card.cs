using System;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Card
    {
        /// <summary>
        /// The suit of the card. Limited to the enum values of Hearts, Spades, Clubs, and Diamonds.
        /// </summary>
        public Suit CardSuit { get; set; }
        /// <summary>
        /// Explicit setter of the card's suit.
        /// </summary>
        /// <param name="suit">The enum value to set the suit of the card to.</param>
        public void SetSuit(Suit suit)
        {
            CardSuit = suit;
        }
        /// <summary>
        /// Explicit getter of the card's suit.
        /// </summary>
        /// <returns>The suit of the card.</returns>
        public Suit GetSuit()
        {
            return CardSuit;
        } 

        /// <summary>
        /// The rank of the card. Limited to the enum values of Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, or Ace.
        /// </summary>
        public Rank CardRank { get; set; }
        /// <summary>
        /// Explicit setter of the card's rank.
        /// </summary>
        /// <param name="suit">The enum value to set the rank of the card to.</param>
        public void SetRank(Rank rank)
        {
            CardRank = rank;
        }
        /// <summary>
        /// Explicit getter of the card's rank.
        /// </summary>
        /// <returns>The rank of the card.</returns>
        public Rank GetRank()
        {
            return CardRank;
        }

        /// <summary>
        /// Constructor for the class. Requires both a rank and a suit from the below enums.
        /// </summary>
        /// <param name="cardRank">The rank of the newly created card. Limited to values from the rank enum below.</param>
        /// <param name="cardSuit">The suit of the newly created card. Limited to values from the suit enum below.</param>
        public Card(Rank cardRank, Suit cardSuit)
        {
            CardRank = cardRank;
            CardSuit = cardSuit;
        }

        /// <summary>
        /// Valid options for the suit of the cards in this class.
        /// </summary>
        public enum Suit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        };

        /// <summary>
        /// Valid options for the rank of cards in this class.
        /// </summary>
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

        /// <summary>
        /// Returns a string that describes the card as a "(Rank) of (Suit)". Mostly for display purposes.
        /// </summary>
        /// <returns>A string in the form of "(Rank) of (Suit)".</returns>
        public string DisplayCard()
        {
            string describeCard = CardRank + " of " + CardSuit;
            return describeCard;
        }

        /// <summary>
        /// Override of the generic equals operator. Determines if the rank and suit of two given cards matches.
        /// </summary>
        /// <param name="a">The first card to be compared.</param>
        /// <param name="b">The second card to be compared.</param>
        /// <returns>If both the rank and suit of two cards match, returns true; otherwise returns false.</returns>
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
