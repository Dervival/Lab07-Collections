# Lab07-Collections
Repository for the Deck (Collections) Lab for Code Fellows seattle-dn-401d6 course

## Day 4 lab: Deck

#### Requirements
- Create a custom generic collection named Deck<T>.
- As we learned, under the hood, generic collections are arrays. Utilizing this concept, create a new generic collection (Deck<T>) that dynamically resizes an array for all the specified methods described below. (*Do not use a collection within your Deck class).
- Your Generic collection should hold Cards. (You will need to create a custom Card class)
- Create an Enum to hold the different card suits (Hearts, Diamonds, Spades, Clubs)
- The methods within your Deck class should contain at minimum:
-- Add
-- Remove
-- Count (the total number of cards in the deck)
- In your Program.cs have a method named Deal that gets called from Main that evenly distributes the deck of cards amongst 2 players decks. the Dealer Deck should keeps any remaining cards (if any). Output to the console the cards each player has and what the Dealer Deck has kept.

#### Setup/Running instructions
- Clone or download this repository into a folder of your choice.
- Open up the solution file in an IDE of your choice, preferably Visual Studio
- Find another player to play tic-tac-toe with.
- Within your IDE, start the solution with or without debugging. Use the console window that opens to type in input.
- The program will run on its own.

#### Sample inputs:
- No sample inputs for this project.

#### Sample outputs:
- There are currently 12 cards in the deck: Ten of Hearts, Four of Clubs, Nine of Diamonds, Eight of Diamonds, Seven of Diamonds, Six of Diamonds, Six of Spades, Six of Hearts, Six of Clubs, Seven of Clubs, Ace of Clubs, Queen of Diamonds, and that's it.
- Now adding the Two of Spades to the deck.
- There are currently 13 cards in the deck: Ten of Hearts, Four of Clubs, Nine of Diamonds, Eight of Diamonds, Seven of Diamonds, Six of Diamonds, Six of Spades, Six of Hearts, Six of Clubs, Seven of Clubs, Ace of Clubs, Queen of Diamonds, Two of Spades, and that's it.

- Now removing the Four of Clubs from the deck.
- In FindCardIndex
- There are currently 12 cards in the deck: Ten of Hearts, Nine of Diamonds, Eight of Diamonds, Seven of Diamonds, Six of Diamonds, Six of Spades, Six of Hearts, Six of Clubs, Seven of Clubs, Ace of Clubs, Queen of Diamonds, Two of Spades, and that's it.

- Now running Deal().

- Player one's deck before deal: Empty
- Player two's deck before deal: Empty
- Dealer's deck before deal: Ten of Hearts, Nine of Diamonds, Eight of Diamonds, Seven of Diamonds, Six of Diamonds, Six of Spades, Six of Hearts, Six of Clubs, Seven of Clubs, Ace of Clubs, Queen of Diamonds, Two of Spades, and that's it.

- Deal complete.

- Player one's deck after deal: Ten of Hearts, Eight of Diamonds, Six of Diamonds, Six of Hearts, Seven of Clubs, Queen of Diamonds, and that's it.
- Player two's deck after deal: Nine of Diamonds, Seven of Diamonds, Six of Spades, Six of Clubs, Ace of Clubs, Two of Spades, and that's it.
- Dealer's deck after deal: Empty

#### Screen captures:
- ![Output](https://github.com/Dervival/Lab07-ClassesAndObjects/blob/master/Deck.PNG);
