using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevInterviewCodeTest.Services.Services.Interfaces;
using DevInterviewCodeTest.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevInterviewCodeTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHandService _handService;

        protected readonly IMapper _mapper;

        public HomeController(IHandService handService, IMapper mapper)
        {
            _handService = handService;
            _mapper = mapper;
        }

        [HttpGet("{count:int?}")]
        public IActionResult Index(int count = 1)
        {
            return View(_handService.GetHands(count).AsQueryable().ProjectTo<HandModel>(_mapper.ConfigurationProvider));
        }
    }
}
