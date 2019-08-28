using System.Collections.Generic;
using System.Linq;
using DevInterviewCodeTest.Web.Models.Enums;

namespace DevInterviewCodeTest.Web.Models
{
    public class Hand
    {
        public Card[] Cards { get; private set; }

        public HandEvaluationEnum Evaluation { get; private set; }

        public Hand(IEnumerable<Card> cards)
        {
            Cards = cards.OrderByDescending(c => c.Rank).ThenBy(c => c.Suit).ToArray();
            Evaluation = Evaluate();
        }

        private HandEvaluationEnum Evaluate()
        {
            if (IsFlush() && IsStraight())
            {
                return HandEvaluationEnum.StraightFlush;
            }

            if (IsSameCard(4))
            {
                return HandEvaluationEnum.FourOfKind;
            }

            if (IsFullHouse())
            {
                return HandEvaluationEnum.FullHouse;
            }

            if (IsFlush())
            {
                return HandEvaluationEnum.Flush;
            }

            if (IsStraight())
            {
                return HandEvaluationEnum.Straight;
            }

            if (IsSameCard(3))
            {
                return HandEvaluationEnum.ThreeOfKind;
            }

            if (IsTwoPair())
            {
                return HandEvaluationEnum.TwoPair;
            }

            if (IsSameCard(2))
            {
                return HandEvaluationEnum.OnePair;
            }

            return HandEvaluationEnum.HighCard;
        }

        private bool IsFlush()
        {
            return 0 != Cards.Select(c => (int)c.Suit).Aggregate((a, s) => a & s);
        }

        private bool IsStraight()
        {
            var cards = Cards.OrderBy(c => c.Rank).ToArray();
            for (int i = 0; i < cards.Count() - 1; i++)
            {
                if (cards[i + 1].Rank - cards[i].Rank != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSameCard(int count)
        {
            return GetValueGroups().FirstOrDefault().Value == count;
        }

        private bool IsFullHouse()
        {
            return IsGroupCount(3, 2);
        }

        private bool IsTwoPair()
        {
            return IsGroupCount(2, 2);
        }

        private bool IsGroupCount(int groupa, int groupb)
        {
            var groups = GetValueGroups();
            if (groups.Count() >= 2)
            {
                return groups.First().Value == groupa && groups.Skip(1).First().Value == groupb;
            }

            return false;
        }

        private IDictionary<CardRankEnum, int> GetValueGroups()
        {
            return Cards.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).ToDictionary(k => k.Key, v => v.Count());
        }
    }
}
