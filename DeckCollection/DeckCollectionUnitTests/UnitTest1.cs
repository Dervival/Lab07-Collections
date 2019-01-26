using System;
using Xunit;
using DeckCollection;
using DeckCollection.Classes;

namespace DeckCollectionUnitTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Adds two cards to the deck and determines the length of the deck, then adds one more card and asserts that the number of cards is not the same as the initial length. Not that good of a test - should be named "AddCardChangesTheCountOfCardsOfDeck" to be more precise, or should be refactored and ran after it's proven we can get properties from the cards at the top of the deck.
        /// </summary>
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
        /// <summary>
        /// Tests the getters of the card class.
        /// </summary>
        [Fact]
        public void CanGetPropertiesFromCardClass()
        {
            Card testCard = new Card(Card.Rank.Nine, Card.Suit.Diamonds);
            Assert.True(Card.Rank.Nine == testCard.GetRank());
            Assert.True(Card.Suit.Diamonds == testCard.GetSuit());
        }
        /// <summary>
        /// Tests the setters of the card class.
        /// </summary>
        [Fact]
        public void CanSetPropertiesToCardClass()
        {
            Card testCard = new Card(Card.Rank.Nine, Card.Suit.Diamonds);
            testCard.CardSuit = Card.Suit.Hearts;
            testCard.CardRank = Card.Rank.Four;
            Assert.False(Card.Rank.Nine == testCard.GetRank());
            Assert.False(Card.Suit.Diamonds == testCard.GetSuit());
        }
        /// <summary>
        /// Tests that removing a card from the first index changes the count of cards in the deck.
        /// </summary>
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
        /// <summary>
        /// Tests that attempting to remove a card that does not exist in the deck does not throw an exception, and does not mutate the length of the deck.
        /// </summary>
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
