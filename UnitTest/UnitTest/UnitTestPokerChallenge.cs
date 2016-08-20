using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerChallengeRef;

namespace UnitTestPokerChallenge
{
    [TestClass]
    public class UnitTestPokerChallenge
    {

        [TestMethod]
        public void TestIsDuplicateCard()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Joe = new PokerPlayer("Joe");
            PokerFirstGame.AddPlayer(Joe);

            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Clubs });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Six, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Jack, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Diamond });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Diamond });

            //Act
            try
            {
                PokerHand pokerHand = PokerFirstGame.GetWinner();
            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "Duplicate card(s) found");
                return;
            }

            Assert.Fail("No exception was thrown.");

        }

        [TestMethod]
        public void TestIsDuplicatePlayer()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Dags = new PokerPlayer("Dags");
            PokerPlayer Joe = new PokerPlayer("Dags");
            
            //Act
            try
            {
                PokerFirstGame.AddPlayer(Dags);
                PokerFirstGame.AddPlayer(Joe);
            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "Player name already exists");
                return;
            }

            Assert.Fail("No exception was thrown.");

        }
    }
}
