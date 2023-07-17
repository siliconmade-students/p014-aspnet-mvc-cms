using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
