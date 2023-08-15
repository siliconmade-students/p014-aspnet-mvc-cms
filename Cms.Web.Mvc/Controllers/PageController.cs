using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            return View();
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
