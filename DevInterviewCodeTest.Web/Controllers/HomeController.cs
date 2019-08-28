using System.Collections.Generic;
using System.Linq;
using DevInterviewCodeTest.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevInterviewCodeTest.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("{count:int?}")]
        public IActionResult Index(int count = 1)
        {
            var model = new List<Hand>();
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                model.Add(deck.GetHand());
            }

            return View(model.OrderBy(h => h.Evaluation).ThenByDescending(h => h.Cards.First().Rank));
        }
    }
}
