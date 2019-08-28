using System.Linq;
using DevInterviewCodeTest.Web.Models;
using Xunit;

namespace DevInterviewCodeTest.Tests
{
    public class DeckTest
    {
        [Fact]
        public void TestDeckHasAllCards()
        {
            var deck = new Deck();
            Assert.Equal(52, deck.Cards.Count());
        }

        [Fact]
        public void TestDeckHasUniqueCards()
        {
            var deck = new Deck();
            Assert.Equal(52, deck.Cards.Distinct().Count());
        }
    }
}
