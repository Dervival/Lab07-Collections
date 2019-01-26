using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckCollection.Classes
{
    public class Deck<T> : IEnumerable<T>
    {
        /// <summary>
        /// Initialization of the deck to 6 members. currentIndex is used to count the number of elements in the internal array internalCards; once we try and add another element past the current length of the array, it triggers a resize operation. currentIndex should be used for the upper boundary for most of the functionality of the deck - there can exist cards past this index since I don't actually delete cards past this index when removing cards, I just treat it as garbage memory to be written over by any newly added cards. 
        /// </summary>
        T[] internalCards = new T[6];
        int currentIndex = 0;

        /// <summary>
        /// Adds a "card" to the deck. Technically, this could be any object as we're using a generic type, but for the purpopse of this lab we'll only be invoking it with arguments of type card.
        /// If adding the card would overflow the internal array, double the size of the array by using GrowArray before adding the card and incrementing the currentIndex counter.
        /// </summary>
        /// <param name="newCard">The element to be added to the deck.</param>
        public void AddCard(T newCard)
        {
            if (currentIndex > internalCards.Length - 1)
            {
                internalCards = GrowArray(internalCards);
            }
            internalCards[currentIndex] = newCard;
            currentIndex++;
        }

        /// <summary>
        /// If the element exists in the deck (as determined by the function FindCardIndex), removes the first instance of it from the deck and returns it (for display purposes, usually). If the element does not exist in the deck, returns the default value of the element (for cards, a null).
        /// </summary>
        /// <param name="removeCard">The element to be removed from the deck.</param>
        /// <returns>The card removed from the deck.</returns>
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

        /// <summary>
        /// Removes the element at index indexToRemove by writing over that element and all elements after it (up to the currentIndex-1) with the next element in the array. The removed element is returned.
        /// </summary>
        /// <param name="indexToRemove">Index to remove an element at.</param>
        /// <returns>The element removed from index indexToRemove.</returns>
        public T RemoveCardAtIndex(int indexToRemove)
        {
            if (indexToRemove > -1)
            {
                T removeCard = internalCards[indexToRemove];
                for (int i = indexToRemove; i < currentIndex-1; i++)
                {
                    internalCards[i] = internalCards[i + 1];
                }
                currentIndex--;
                return removeCard;
            }
            return default(T);
        }

        /// <summary>
        /// Retrieves an element at index i if i is a valid index in the deck. Otherwise, returns the default value of the type of elements in the deck (typically null)
        /// </summary>
        /// <param name="i">The index to be retrieved.</param>
        /// <returns>The element at the index provided.</returns>
        public T GetCardAtIndex(int i)
        {
            if(i < CountCards() -1 && i > 0)
            {
                return internalCards[i];
            }
            return default(T);
        }

        /// <summary>
        /// Given an element, attempts to find the index of the deck where the first instance of that element resides. If no instances of that element are in the deck, returns -1.
        /// </summary>
        /// <param name="card">The element whose index is to be retrieved.</param>
        /// <returns>The index of the element in the deck, or -1 if the element does not exist in the deck.</returns>
        public int FindCardIndex(T card)
        {
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

        /// <summary>
        /// Given an array with elements, creates a new array twice the size of the original array and copies over all elements in-order to the new array. This does not mutate the original array, so the returned array must be assigned to something for this method to be useful.
        /// </summary>
        /// <param name="arrayToResize">The base array to resize off of.</param>
        /// <returns>A new array twice the size of the previous array containing all elements of the previous array.</returns>
        public T[] GrowArray(T[] arrayToResize)
        {
            T[] newArray = new T[arrayToResize.Length * 2];
            for (int i = 0; i < arrayToResize.Length; i++)
            {
                newArray[i] = arrayToResize[i];
            }
            return newArray;
        }

        /// <summary>
        /// Interface for getting the value of the current number of valid elements in the deck.
        /// </summary>
        /// <returns>The number of elements in the deck.</returns>
        public int CountCards()
        {
            return currentIndex;
        }

        //IEnumerable interface methods
        //required for legacy C# 1.0 applications apparently
        /// <summary>
        /// Standard method required for the IEnumerable interface. Required for compatibility with C# 1.0 applications.
        /// </summary>
        /// <returns>A non-generic IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Allows for foreach, which is a requirement for this lab
        /// <summary>
        /// Returns the enumerator of the internal array of the deck. Required for foreach and other methods requiring the IEnumerable interface for implementation.
        /// </summary>
        /// <returns>The current enumerator of the index.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                yield return internalCards[i];
            }
        }
    }
}
