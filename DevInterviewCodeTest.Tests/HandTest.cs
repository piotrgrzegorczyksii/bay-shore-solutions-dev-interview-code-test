using System;
using System.Linq;
using DevInterviewCodeTest.Web.Models;
using DevInterviewCodeTest.Web.Models.Enums;
using Xunit;

namespace DevInterviewCodeTest.Tests
{
    public class HandTest
    {
        [Theory]
        [InlineData("9s 10s Js Qs Ks")]
        [InlineData("6h 3h 2h 4h 5h")]
        [InlineData("Jd Qd Kd Ad 10d")]
        public void TestStraightFlush(string value)
        {
            TestHand(HandEvaluationEnum.StraightFlush, value);
        }

        [Theory]
        [InlineData("4s 4d Qs 4h 4c")]
        [InlineData("Qh Qs Qd 10c Qc")]
        [InlineData("10c 10d Kd 10s 10h")]
        public void TestFourOfKind(string value)
        {
            TestHand(HandEvaluationEnum.FourOfKind, value);
        }

        [Theory]
        [InlineData("5d 4h 5s 4h 4c")]
        [InlineData("Ah As 10d 10c 10h")]
        [InlineData("2c 8d 8h 8s 2h")]
        public void TestFullHouse(string value)
        {
            TestHand(HandEvaluationEnum.FullHouse, value);
        }

        [Theory]
        [InlineData("Kh Qh 6h 2h 9h")]
        [InlineData("5s 10s Js As 2s")]
        [InlineData("2d Ad Qd 10d 7d")]
        public void TestFlush(string value)
        {
            TestHand(HandEvaluationEnum.Flush, value);
        }

        [Theory]
        [InlineData("5d 2h 3s 4h 6c")]
        [InlineData("Ah Ks 10d Jc Qh")]
        [InlineData("6c 7d 8h 10s 9h")]
        public void TestStraight(string value)
        {
            TestHand(HandEvaluationEnum.Straight, value);
        }

        [Theory]
        [InlineData("7d 7h Qs 7d 6c")]
        [InlineData("As Js Jd 2c Jh")]
        [InlineData("Qh 10d 8h Qs Qd")]
        public void TestThreeOfKind(string value)
        {
            TestHand(HandEvaluationEnum.ThreeOfKind, value);
        }

        [Theory]
        [InlineData("Kh Kc 3s 3h 2d")]
        [InlineData("As Ac 8h 8c 10d")]
        [InlineData("2s 3c 2h Jd Js")]
        public void TestTwoPair(string value)
        {
            TestHand(HandEvaluationEnum.TwoPair, value);
        }

        [Theory]
        [InlineData("Ah As 10c 7d 6s")]
        [InlineData("Ks Ks 3d 4d 10s")]
        [InlineData("2d 3c 7h 8c 3s")]
        public void TestOnePair(string value)
        {
            TestHand(HandEvaluationEnum.OnePair, value);
        }

        [Theory]
        [InlineData("Ah Qs 10c 7d 6s")]
        [InlineData("2s Ks 3d 4d 10s")]
        [InlineData("5d 3c 7h 8c 6d")]
        public void TestHighCard(string value)
        {
            TestHand(HandEvaluationEnum.HighCard, value);
        }

        private static void TestHand(HandEvaluationEnum evaluation, string value)
        {
            var hand = CreateHand(value);
            Assert.Equal(evaluation, hand.Evaluation);
        }

        private static Hand CreateHand(string value)
        {
            return new Hand(value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(CreateCard));
        }

        private static Card CreateCard(string value)
        {
            var suit = value.Last();
            var rank = value.TrimEnd(new[] { suit });
            return new Card()
            {
                Rank = GetCardRank(rank),
                Suit = GetCardSuit(suit.ToString())
            };
        }

        private static CardRankEnum GetCardRank(string rank)
        {
            if (int.TryParse(rank, out int intRank))
            {
                return (CardRankEnum)intRank;
            }

            switch (rank.ToUpper())
            {
                case "J":
                    return CardRankEnum.Jack;
                case "Q":
                    return CardRankEnum.Queen;
                case "K":
                    return CardRankEnum.King;
                case "A":
                    return CardRankEnum.Ace;
            }

            throw new Exception("Unknown rank");
        }

        private static CardSuitEnum GetCardSuit(string suit)
        {
            switch (suit.ToUpper())
            {
                case "C":
                    return CardSuitEnum.Clubs;
                case "D":
                    return CardSuitEnum.Diamonds;
                case "H":
                    return CardSuitEnum.Hearts;
                case "S":
                    return CardSuitEnum.Spades;
            }

            throw new Exception("Unknown suit");
        }
    }
}
