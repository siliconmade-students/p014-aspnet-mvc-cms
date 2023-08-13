using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IPostService _postService;
        public DepartmentController(IPostService postService)
        {
			_postService = postService;

		}

        public IActionResult Index()
        {
            return View();
        }

        [Route("Department/{slug}")]
        public IActionResult Filter(string slug, int page =1 )
        {
            return View(_postService.GetByDepartmentSlug(slug, page));
        }
    }
}
