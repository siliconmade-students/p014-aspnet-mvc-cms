using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IPostService _postService;

		public BlogController(IPostService postService)
		{
			_postService = postService;
		}

		public IActionResult Index(int page = 1)
		{
			int maxPage = _postService.GetMaxPageCount();
			if (page > maxPage)
			{
				return Redirect("Blog?page=" + maxPage);
			}
			else if (page < 1)
			{
				return Redirect("Blog?page=" + 1);
			}
			var departmanDto = new DepartmentDto();
			
			ViewBag.currentPage = page;
			ViewBag.maxPage = maxPage;
			return View(_postService.GetAll(page));
		}
	}
}
