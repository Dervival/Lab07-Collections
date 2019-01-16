using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Deck<Card> : IEnumerable<Card>
    {
        Card[] internalCards = new Card[6];
        int currentIndex = 0;

        public void AddCard(Card newCard)
        {
            if (currentIndex > internalCards.Length - 1)
            {
                internalCards = GrowArray(internalCards);
            }
            internalCards[currentIndex] = newCard;
            currentIndex++;
        }
        public void RemoveCard(Card removeCard)
        {
            int indexToRemove = FindCardIndex(removeCard);
            for (int i = indexToRemove; i < currentIndex; i++)
            {
                internalCards[i] = internalCards[i + 1];
            }
            //using default(Card) instead of null to remove the last card
            internalCards[currentIndex] = default(Card);
            currentIndex--;
        }
        public int FindCardIndex(Card card)
        {
            Console.WriteLine("In FindCardIndex");
            int index = -1;
            for (int i = 0; i < internalCards.Length; i++)
            {
                if (Equals(internalCards[i], card))
                {
                    index = i;
                }
            }
            return index;
        }

        public Card[] GrowArray(Card[] arrayToResize)
        {
            Console.WriteLine("Resizing array to " + arrayToResize.Length * 2 + " elements");
            Card[] newArray = new Card[arrayToResize.Length * 2];
            for (int i = 0; i < arrayToResize.Length; i++)
            {
                newArray[i] = arrayToResize[i];
            }
            return newArray;
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
            for (int i = 0; i < currentIndex; i++)
            {
                yield return internalCards[i];
            }
        }
    }
}
