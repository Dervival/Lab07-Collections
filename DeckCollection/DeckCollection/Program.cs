using System;
using System.Collections;
using System.Collections.Generic;
using DeckCollection.Classes;

namespace DeckCollection
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Card testCard = new Card(Card.Rank.Ten, Card.Suit.Hearts);
            Card nextCard = new Card(Card.Rank.Four, Card.Suit.Clubs);
            //Card.DisplayCard(testCard);
            Deck<Card> testDeck = new Deck<Card>();
            testDeck.AddCard(testCard);
            testDeck.AddCard(nextCard);
            foreach (Card card in testDeck)
            {
                DisplayCard(card);
            }
            //Can't do this, changes card in the deck since it passes the reference
            //nextCard.CardRank = Card.Rank.Nine;
            //nextCard.CardSuit = Card.Suit.Diamonds;
            AddCardToDeck(Card.Rank.Nine, Card.Suit.Diamonds, testDeck);
            DisplayDeck(testDeck);
            AddCardToDeck(Card.Rank.Eight, Card.Suit.Diamonds, testDeck);
            DisplayDeck(testDeck);
            AddCardToDeck(Card.Rank.Seven, Card.Suit.Diamonds, testDeck);
            DisplayDeck(testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Diamonds, testDeck);
            DisplayDeck(testDeck);
            AddCardToDeck(Card.Rank.Six, Card.Suit.Spades, testDeck);
            DisplayDeck(testDeck);
            testDeck.RemoveCard(nextCard);
            AddCardToDeck(0, 0, testDeck);
            DisplayDeck(testDeck);
        }

        public static void DisplayCard(Card card)
        {
            Console.WriteLine(card.CardRank + " of " + card.CardSuit);
        }

        public static void DisplayDeck(Deck<Card> deck)
        {
            foreach (Card card in deck)
            {
                DisplayCard(card);
            }
        }

        public static void AddCardToDeck(Card.Rank rank, Card.Suit suit, Deck<Card> deck)
        {
            Card addedCard = new Card(rank, suit);
            deck.AddCard(addedCard);
        }

        
    }
}
