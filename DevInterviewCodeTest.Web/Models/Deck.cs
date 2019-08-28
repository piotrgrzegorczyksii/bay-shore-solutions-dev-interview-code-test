using System;
using System.Collections.Generic;
using System.Linq;
using DevInterviewCodeTest.Web.Models.Enums;

namespace DevInterviewCodeTest.Web.Models
{
    public class Deck
    {
        public Card[] Cards;

        public Deck()
        {
            var cards = new List<Card>();

            foreach (CardSuitEnum suit in (CardSuitEnum[])Enum.GetValues(typeof(CardSuitEnum)))
            {
                foreach (CardRankEnum value in (CardRankEnum[])Enum.GetValues(typeof(CardRankEnum)))
                {
                    cards.Add(new Card
                    {
                        Suit = suit,
                        Rank = value
                    });
                }
            }

            Cards = cards.ToArray();
            Shuffle();
        }

        public Hand GetHand()
        {
            Shuffle();
            return new Hand(Cards.Take(5).ToArray());
        }

        public void Shuffle()
        {
            var n = Cards.Length;
            var random = new Random();

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}
