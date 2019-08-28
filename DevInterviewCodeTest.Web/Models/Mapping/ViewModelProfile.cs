using AutoMapper;
using DevInterviewCodeTest.Services.Models;

namespace DevInterviewCodeTest.Web.Models.Mapping
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<Card, CardModel>();
            CreateMap<Hand, HandModel>();
        }
    }
}
