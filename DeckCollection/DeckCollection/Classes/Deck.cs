using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Deck<T> : IEnumerable<T>
    {
        T[] internalCards = new T[6];
        int currentIndex = 0;

        public void AddCard(T newCard)
        {
            if (currentIndex > internalCards.Length - 1)
            {
                internalCards = GrowArray(internalCards);
            }
            internalCards[currentIndex] = newCard;
            currentIndex++;
        }
        public T RemoveCard(T removeCard)
        {
            int indexToRemove = FindCardIndex(removeCard);
            if (indexToRemove > -1)
            {
                for (int i = indexToRemove; i < currentIndex; i++)
                {
                    internalCards[i] = internalCards[i + 1];
                }
                //using default(Card) instead of null to remove the last card
                internalCards[currentIndex] = default(T);
                currentIndex--;
                return removeCard;
            }
            return default(T);
        }
        public T RemoveCardAtIndex(int indexToRemove)
        {
            if (indexToRemove > -1)
            {
                T removeCard = internalCards[indexToRemove];
                //Console.WriteLine("In RemoveCardAtIndex, currentIndex is " + currentIndex);
                for (int i = indexToRemove; i < currentIndex-1; i++)
                {
                    //Console.WriteLine("i is " + i);
                    internalCards[i] = internalCards[i + 1];
                }
                currentIndex--;
                
                return removeCard;
            }
            return default(T);
        }

        public T GetCardAtIndex(int i)
        {
            if(i < CountCards() -1 && i > 0)
            {
                return internalCards[i];
            }
            return default(T);
        }

        public int FindCardIndex(T card)
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

        public T[] GrowArray(T[] arrayToResize)
        {
            //Console.WriteLine("Resizing array to " + arrayToResize.Length * 2 + " elements");
            T[] newArray = new T[arrayToResize.Length * 2];
            for (int i = 0; i < arrayToResize.Length; i++)
            {
                newArray[i] = arrayToResize[i];
            }
            return newArray;
        }

        public int CountCards()
        {
            return currentIndex;
        }

        //IEnumerable interface methods
        //required for legacy C# 1.0 applications apparently
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Allows for foreach, which is a requirement for this lab
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                yield return internalCards[i];
            }
        }
    }
}
