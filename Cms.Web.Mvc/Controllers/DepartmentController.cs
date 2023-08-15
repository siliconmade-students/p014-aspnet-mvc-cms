using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
		}

        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
        
        [Route("Department/{slug}")]
        public IActionResult Single(string slug)
        {
			return View(_departmentService.GetByDepartmentSlug(slug));
		}

        public IActionResult Filter(string slug, int page =1 )
        {
            return View();
        }

        
    }
}
