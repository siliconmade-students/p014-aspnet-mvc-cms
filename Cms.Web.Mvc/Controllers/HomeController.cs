using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Diagnostics;

namespace Cms.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly Statistics _statistics;

		public HomeController(IOptions<Statistics> statistics)
		{
            _statistics = statistics.Value;
		}

		public IActionResult Index()
        {
			ViewBag.Clients = _statistics.Clients;
            ViewBag.Operations= _statistics.Operations;
            ViewBag.Doctors= _statistics.Doctors;
            ViewBag.YearsOfExperience = _statistics.YearsOfExperience;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}