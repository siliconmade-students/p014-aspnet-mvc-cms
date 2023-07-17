using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
