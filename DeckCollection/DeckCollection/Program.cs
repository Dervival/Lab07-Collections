using System;
using System.Collections;
using System.Collections.Generic;
using DeckCollection.Classes;

namespace DeckCollection
{
    public class Program
    {
        /// <summary>
        /// Main method to showoff the various features of the deck implementation through a console application.
        /// </summary>
        /// <param name="args">Any arguments to pass into the application - in this case, none are used.</param>
        public static void Main(string[] args)
        {
            //Instantiation of the generic collection, where T = Card;
            Deck<Card> testDeck = new Deck<Card>();
            //Adding two cards directly by creating a card then adding it to the deck...
            Card testCard = new Card(Card.Rank.Ten, Card.Suit.Hearts);
            Card nextCard = new Card(Card.Rank.Four, Card.Suit.Clubs);
            testDeck.AddCard(testCard);
            testDeck.AddCard(nextCard);
            //Adding the other 10 cards meet the 10+ instantiation requirement
            AddCardToDeck(Card.Rank.Nine, Card.Suit.Diamonds, testDeck);
            AddCardToDeck(Card.Rank.Eight, Card.Suit.Diamonds, testDeck);
            AddCardToDeck(Card.Rank.Seven, Card.Suit.Diamonds, testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Diamonds, testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Spades, testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Hearts, testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Clubs, testDeck);
            AddCardToDeck(Card.Rank.Seven, Card.Suit.Clubs, testDeck);
            AddCardToDeck(Card.Rank.Ace, Card.Suit.Clubs, testDeck);
            AddCardToDeck(Card.Rank.Queen, Card.Suit.Diamonds, testDeck);
            //Showing that add and remove actually change the state of the deck
            Console.WriteLine("Welcome to my Deck program.\n");
            Console.Write("There are currently " + testDeck.CountCards() + " cards in the deck: ");
            //required foreach loop in DisplayDeck
            DisplayDeck(testDeck);
            Card addCard = new Card(Card.Rank.Two, Card.Suit.Spades);
            Console.WriteLine("\nNow adding the " + addCard.DisplayCard() + " to the deck.");
            testDeck.AddCard(addCard);
            Console.Write("There are currently " + testDeck.CountCards() + " cards in the deck: ");
            DisplayDeck(testDeck);
            Console.WriteLine("\nNow removing the " + nextCard.DisplayCard() + " from the deck.");
            testDeck.RemoveCard(nextCard);
            Console.Write("There are currently " + testDeck.CountCards() + " cards in the deck: ");
            DisplayDeck(testDeck);
            //Calling Deal();
            Deal(testDeck);
        }

        /// <summary>
        /// Iterates through a deck of cards using a foreach loop to describe the cards in a deck. Since this is contingent on the elements in a Deck being of type Card instead of a generic type T, it does not belong in the deck class.
        /// </summary>
        /// <param name="deck">The deck to be displayed.</param>
        public static void DisplayDeck(Deck<Card> deck)
        {
            if(deck.CountCards() < 1)
            {
                Console.WriteLine("Empty");
                return;
            }
            foreach (Card card in deck)
            {
                Console.Write(card.DisplayCard() + ", ");
            }
            Console.WriteLine("and that's it.");   
        }

        /// <summary>
        /// Adds a card to the deck using the AddCard functionality of the deck class.
        /// </summary>
        /// <param name="rank">Rank of the card to be added.</param>
        /// <param name="suit">Suit of the card to be added.</param>
        /// <param name="deck">Deck to add the card to.</param>
        public static void AddCardToDeck(Card.Rank rank, Card.Suit suit, Deck<Card> deck)
        {
            Card addedCard = new Card(rank, suit);
            deck.AddCard(addedCard);
        }

        /// <summary>
        /// Function that takes a given deck and "deals" an equal number of cards to two internal players, displaying the state of all three decks before and after the deal. Dealing is done by removing the top card of the dealer's deck and adding it to a player's hand. If the dealer's deck has an even number of cards, all cards are dealt from the dealer's deck; if not, all but one are dealt and the final card is kept by the dealer. Mutates the dealer's deck. The player's hands are not kept after the method is complete.
        /// </summary>
        /// <param name="dealer">The deck to deal cards from.</param>
        public static void Deal(Deck<Card> dealer)
        {
            Console.WriteLine("\nNow running Deal().");
            Deck<Card> playerOne = new Deck<Card>();
            Deck<Card> playerTwo = new Deck<Card>();
            Console.Write("\nPlayer one's deck before deal: ");
            DisplayDeck(playerOne);
            Console.Write("Player two's deck before deal: ");
            DisplayDeck(playerTwo);
            Console.Write("Dealer's deck before deal: ");
            DisplayDeck(dealer);
            int cardsToDeal = dealer.CountCards();
            if(cardsToDeal % 2 == 1){
                cardsToDeal--;
            }
            for (int i = 0; i < cardsToDeal; i++)
            {
                if(i % 2 == 0)
                {
                    playerOne.AddCard(dealer.RemoveCardAtIndex(0));
                }
                else
                {
                    playerTwo.AddCard(dealer.RemoveCardAtIndex(0));
                }
            }
            Console.WriteLine("\nDeal complete.");
            Console.Write("\nPlayer one's deck after deal: ");
            DisplayDeck(playerOne);
            Console.Write("Player two's deck after deal: ");
            DisplayDeck(playerTwo);
            Console.Write("Dealer's deck after deal: ");
            DisplayDeck(dealer);
        }
    }
}
