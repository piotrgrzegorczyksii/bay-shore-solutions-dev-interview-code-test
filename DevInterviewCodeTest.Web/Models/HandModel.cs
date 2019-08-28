using DevInterviewCodeTest.Services.Models.Enums;

namespace DevInterviewCodeTest.Web.Models
{
    public class HandModel
    {
        public CardModel[] Cards { get; set; }
        public HandEvaluationEnum Evaluation { get; set; }
    }
}
