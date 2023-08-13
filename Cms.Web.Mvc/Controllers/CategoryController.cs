using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPostService _postService;
        public CategoryController(IPostService postService)
        {
            _postService = postService;

        }

        [Route("Category/{category}")]
        public IActionResult Filter(string category, int page = 1)
        {
            return View(_postService.GetByCategory(category, page));
        }
    }
}
