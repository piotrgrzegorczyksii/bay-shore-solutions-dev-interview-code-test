using DevInterviewCodeTest.Services.Models.Enums;
using DevInterviewCodeTest.Web.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DevInterviewCodeTest.Web.TagHelpers
{
    public class CardSuitTagHelper : TagHelper
    {
        public CardModel Card { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            switch (Card.Suit)
            {
                case CardSuitEnum.Diamonds:
                case CardSuitEnum.Hearts:
                    output.Attributes.Add("style", "color: red");
                    break;
            }

            var content = "";

            switch (Card.Suit)
            {
                case CardSuitEnum.Clubs:
                    content += "&clubs;";
                    break;
                case CardSuitEnum.Diamonds:
                    content += "&diams;";
                    break;
                case CardSuitEnum.Hearts:
                    content += "&hearts;";
                    break;
                case CardSuitEnum.Spades:
                    content += "&spades;";
                    break;
            }

            output.Content.SetHtmlContent(content);
        }
    }
}
