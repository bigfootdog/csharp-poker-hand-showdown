## C# Poker Hand Showdown

This Solution implements a library using C# that evaluates the winner among several 5 card poker hands. This project implements only a subset of the regular poker hands:  Flush,Three of a Kind, One Pair and High Card.

### Requirements (Based on Assumption):
1. Create a Library that evaluates who is the winner(s) among several 5 card poker hands.
2. Need only need to implement a subset of the regular poker hands:  Flush,  Three of a Kind,  One Pair and High Card.
3. Create a sample unit test for the library.

### Project solution contains: 

1. Demo Application (Console Application) 
2. Reference (Class Library) 
3. Unit Test (Unit test) 

##Object Oriented Programming
### Participants

* PokerPlayer
	* ReceivePlayingCard (param PlayingCard)
	* Join (param PokerGame)
	* GetPokerHand (ret PokerHand)
	* ClearCards

* PokerHand
	* IsFlush (Boolean)
  * IsPair (Boolean)
  * IsThreeOfAKind (Boolean)
  * DominantSuit (SuitType)
  * DominantRank (RankType)
  * HandCategory (Category)
  * Score (Int)

* PokerGame
	* GivePlayingCards (param PokerPlayer, PlayingCard)
  * AddPlayer (param PokerPlayer)
  * Evaluate 
  * GetWinner (return PokerHand)
        
