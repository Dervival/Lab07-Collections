using System;
using DeckCollection.Classes;

namespace DeckCollection
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Card testCard = new Card(Card.Rank.Ten, Card.Suit.Hearts);
            Card.DisplayCard(testCard);
        }
    }
}
