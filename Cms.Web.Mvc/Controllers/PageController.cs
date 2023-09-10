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
        [Route("Page/{slug}")]
        public ActionResult Index(string slug)
        {
            var page = _pageService.GetBySlug(slug);

            return View(page);
        }
       
    }
}
