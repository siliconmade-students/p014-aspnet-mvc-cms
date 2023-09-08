using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{

    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            var page = _pageService.GetById(1);

            return View(page);
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
       
    }
}
