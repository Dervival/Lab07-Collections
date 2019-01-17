using System;
using Xunit;
using DeckCollection;
using DeckCollection.Classes;

namespace DeckCollectionUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddCardToDeckAddsCard()
        {
            Deck<Card> testDeck = new Deck<Card>();
            Card testCard = new Card(Card.Rank.Ten, Card.Suit.Hearts);
            Card nextCard = new Card(Card.Rank.Four, Card.Suit.Clubs);
            testDeck.AddCard(testCard);
            testDeck.AddCard(nextCard);
            int firstLength = testDeck.CountCards();
            Program.AddCardToDeck(Card.Rank.Six, Card.Suit.Diamonds, testDeck);
            Assert.False(firstLength == testDeck.CountCards());
        }
        [Fact]
        public void CanGetPropertiesFromCardClass()
        {
            Card testCard = new Card(Card.Rank.Nine, Card.Suit.Diamonds);
            Assert.True(Card.Rank.Nine == testCard.GetRank());
            Assert.True(Card.Suit.Diamonds == testCard.GetSuit());
        }
        [Fact]
        public void CanSetPropertiesToCardClass()
        {
            Card testCard = new Card(Card.Rank.Nine, Card.Suit.Diamonds);
            testCard.CardSuit = Card.Suit.Hearts;
            testCard.CardRank = Card.Rank.Four;
            Assert.False(Card.Rank.Nine == testCard.GetRank());
            Assert.False(Card.Suit.Diamonds == testCard.GetSuit());
        }
        [Fact]
        public void CanRemoveCardThatExistsInDeck()
        {
            Deck<Card> testDeck = new Deck<Card>();
            Program.AddCardToDeck(Card.Rank.Four, Card.Suit.Diamonds, testDeck);
            Program.AddCardToDeck(Card.Rank.Five, Card.Suit.Diamonds, testDeck);
            Program.AddCardToDeck(Card.Rank.Six, Card.Suit.Diamonds, testDeck);
            int firstLength = testDeck.CountCards();
            testDeck.RemoveCardAtIndex(0);
            Assert.False(firstLength == testDeck.CountCards());
        }
        [Fact]
        public void CanRemoveCardThatDoesNotExistsInDeck()
        { 
            Deck<Card> testDeck = new Deck<Card>();
            Program.AddCardToDeck(Card.Rank.Four, Card.Suit.Diamonds, testDeck);
            Program.AddCardToDeck(Card.Rank.Five, Card.Suit.Diamonds, testDeck);
            Program.AddCardToDeck(Card.Rank.Six, Card.Suit.Diamonds, testDeck);
            int firstLength = testDeck.CountCards();
            testDeck.RemoveCardAtIndex(-1);
            Assert.True(firstLength == testDeck.CountCards());
        }
    }
}
