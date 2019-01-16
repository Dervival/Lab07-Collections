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

        public class Deck<Card> : IEnumerable<Card>
        {
            readonly Card[] internalCards = new Card[6];
            int currentIndex = 0;

            public void AddCard(Card newCard)
            {
                internalCards[currentIndex] = newCard;
                currentIndex++;
            }

            //IEnumerable interface methods
            //required for legacy C# 1.0 applications apparently
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            //Allows for foreach, which is a requirement for this lab
            public IEnumerator<Card> GetEnumerator()
            {
                for(int i = 0; i < currentIndex; i++)
                {
                    yield return internalCards[i];
                }
            }
        }
    }
}
