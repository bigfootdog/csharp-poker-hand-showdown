using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerChallengeRef;

namespace UnitTestPokerChallenge
{
    [TestClass]
    public class UnitTestPokerHand
    {
        [TestMethod]
        public void TestIsCategoryFlush()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Joe = new PokerPlayer("Joe");
            PokerFirstGame.AddPlayer(Joe);

            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Three, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Six, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Eight, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.Jack, Suit = SuitType.Heart });
            PokerFirstGame.GivePlayingCards(Joe, new PlayingCard { Rank = RankType.King, Suit = SuitType.Heart });

            //Act
            PokerHand pokerHand = Joe.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.Flush);

        }

        [TestMethod]
        public void TestIsCategoryThreeOfAKind()
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

            //Act
            PokerHand pokerHand = Joe.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.ThreeOfaKind);

        }


    }
}
