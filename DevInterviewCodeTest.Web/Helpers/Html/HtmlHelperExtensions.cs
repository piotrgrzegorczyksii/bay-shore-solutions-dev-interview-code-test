using System;
using System.Linq;
using DevInterviewCodeTest.Services.Models.Enums;
using DevInterviewCodeTest.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevInterviewCodeTest.Web.Helpers.Html
{
    public static class HtmlHelperExtensions
    {
        public static ExtensionPoint<IHtmlHelper> DevInterviewCodeTest(this IHtmlHelper target)
        {
            return new ExtensionPoint<IHtmlHelper>(target);
        }

        public static string CardRank(this ExtensionPoint<IHtmlHelper> instance, CardModel card)
        {
            return (int)card.Rank <= 10
                ? ((int)card.Rank).ToString()
                : Enum.GetName(typeof(CardRankEnum), card.Rank).FirstOrDefault().ToString();
        }

        public static string HandEvaluation(this ExtensionPoint<IHtmlHelper> instance, HandModel hand)
        {
            var content = "High card";

            switch (hand.Evaluation)
            {
                case HandEvaluationEnum.StraightFlush:
                    content = "Straight Flush";
                    break;
                case HandEvaluationEnum.FourOfKind:
                    content = "Four of Kind";
                    break;
                case HandEvaluationEnum.FullHouse:
                    content = "Full House";
                    break;
                case HandEvaluationEnum.Flush:
                    content = "Flush";
                    break;
                case HandEvaluationEnum.Straight:
                    content = "Straight";
                    break;
                case HandEvaluationEnum.ThreeOfKind:
                    content = "Three of Kind";
                    break;
                case HandEvaluationEnum.TwoPair:
                    content = "2 Pair";
                    break;
                case HandEvaluationEnum.OnePair:
                    content = $"Pair of {GetPairLiteral(hand)}";
                    break;
            }

            return content;
        }

        private static string GetPairLiteral(HandModel hand)
        {
            var rank = (int)hand.Cards.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).First().First().Rank;
            if (rank == 2)
            {
                return "deuces";
            }
            else if (rank <= 10)
            {
                return ((int)rank).ToString();
            }
            else
            {
                return $"{Enum.GetName(typeof(CardRankEnum), rank).ToLower()}s";
            }
        }
    }
}
