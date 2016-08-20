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
            PlayPokerGame PokerFirstGame = new PlayPokerGame();
            
            PokerPlayer Joe = new PokerPlayer("Joe");
            PokerPlayer Jen = new PokerPlayer("Jen");
            PokerPlayer Bob = new PokerPlayer("Bob");
           
            PokerFirstGame.AddPlayer(Joe);
            PokerFirstGame.AddPlayer(Bob);
            PokerFirstGame.AddPlayer(Jen);

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
                   
            PokerHand firstWinner = PokerFirstGame.GetWinner();

            Console.WriteLine("Winner for the first game is: {0}, {1}", firstWinner.Name, firstWinner.Category.ToString());


            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key to proceed to the next round");
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
                        
            PlayPokerGame PokerSecondGame = new PlayPokerGame();

            Joe.ClearCards();
            Bob.ClearCards();
            Jen.ClearCards();

            PokerSecondGame.AddPlayer(Joe);
            PokerSecondGame.AddPlayer(Jen);
            PokerSecondGame.AddPlayer(Bob);

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
            
            PokerHand secondWinner = PokerSecondGame.GetWinner();            
            Console.WriteLine("Winner for the second game is: {0}, {1}", secondWinner.Name, secondWinner.Category.ToString());
            
            Console.ReadKey();

        }
    }

}
