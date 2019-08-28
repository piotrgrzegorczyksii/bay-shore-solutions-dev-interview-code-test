using System.Collections.Generic;
using System.Linq;
using DevInterviewCodeTest.Services.Models;
using DevInterviewCodeTest.Services.Services.Interfaces;

namespace DevInterviewCodeTest.Services.Services
{
    public class HandService : IHandService
    {
        public IEnumerable<Hand> GetHands(int count = 1)
        {
            var result = new List<Hand>();
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                result.Add(deck.GetHand());
            }

            return result.OrderBy(h => h.Evaluation).ThenByDescending(h => h.Cards.First().Rank);
        }
    }
}
