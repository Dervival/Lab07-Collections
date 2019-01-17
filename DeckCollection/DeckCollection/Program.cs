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

        public static void AddCardToDeck(Card.Rank rank, Card.Suit suit, Deck<Card> deck)
        {
            Card addedCard = new Card(rank, suit);
            deck.AddCard(addedCard);
        }

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
