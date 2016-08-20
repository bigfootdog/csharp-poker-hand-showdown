using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerChallengeRef;

namespace PokerChallengeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create object for the first game
            PlayPokerGame PokerFirstGame = new PlayPokerGame();
            
            //Create object players
            PokerPlayer Joe = new PokerPlayer("Joe");
            PokerPlayer Jen = new PokerPlayer("Jen");
            PokerPlayer Bob = new PokerPlayer("Bob");
           
            //Added players to the first poker game object
            PokerFirstGame.AddPlayer(Joe);
            PokerFirstGame.AddPlayer(Bob);
            PokerFirstGame.AddPlayer(Jen);

            //Assign cards to the players using poker game object
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Six, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Jack, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.King, Suit = SuitType.Heart });

            PokerFirstGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Clubs });
            PokerFirstGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Diamond });
            PokerFirstGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Spades });
            PokerFirstGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Clubs });
            PokerFirstGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Ten, Suit = SuitType.Diamond });

            PokerFirstGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Two, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Five, Suit = SuitType.Clubs });
            PokerFirstGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Seven, Suit = SuitType.Spades });
            PokerFirstGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Ten, Suit = SuitType.Clubs });
            PokerFirstGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Ace, Suit = SuitType.Heart });

            //Evaluate and get the second winner
            PokerHand firstWinner = PokerFirstGame.GetWinner();                      

            Console.WriteLine("Winner for the first game is: {0} using {1}", firstWinner.Name, firstWinner.Category.ToString());
            
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key to proceed to the next round");
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();

            //Create object for the first game            
            PlayPokerGame PokerSecondGame = new PlayPokerGame();

            //Used the same object for the player and cleared the cards for the new round
            Joe.ClearCards();
            Bob.ClearCards();
            Jen.ClearCards();

            //Added players to the second poker game object
            PokerSecondGame.AddPlayer(Joe);
            PokerSecondGame.AddPlayer(Jen);
            PokerSecondGame.AddPlayer(Bob);

            //Assign cards to the players using poker game object
            PokerSecondGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Heart });
            PokerSecondGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Four, Suit = SuitType.Diamond });
            PokerSecondGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Nine, Suit = SuitType.Clubs });
            PokerSecondGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Nine, Suit = SuitType.Diamond });
            PokerSecondGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Queen, Suit = SuitType.Heart });
                        
            PokerSecondGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Five, Suit = SuitType.Clubs });
            PokerSecondGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Seven, Suit = SuitType.Diamond });
            PokerSecondGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Nine, Suit = SuitType.Heart });
            PokerSecondGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Nine, Suit = SuitType.Spades });
            PokerSecondGame.GivePlayingCards(Jen, new PlayingCard { Rank = RankType.Queen, Suit = SuitType.Spades });
                        
            PokerSecondGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Two, Suit = SuitType.Heart });
            PokerSecondGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Two, Suit = SuitType.Clubs });
            PokerSecondGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Five, Suit = SuitType.Spades });
            PokerSecondGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Ten, Suit = SuitType.Clubs });
            PokerSecondGame.GivePlayingCards(Bob, new PlayingCard { Rank = RankType.Ace, Suit = SuitType.Heart });
            
            //Evaluate and get the second winner
            PokerHand secondWinner = PokerSecondGame.GetWinner();       
     
            Console.WriteLine("Winner for the second game is: {0} using {1}", secondWinner.Name, secondWinner.Category.ToString());
            
            Console.ReadKey();

        }
    }

}
