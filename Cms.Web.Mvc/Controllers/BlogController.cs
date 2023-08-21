using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Cms.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;

        public BlogController(IPostService postService)
        {
            _postService= postService;
        }

        public IActionResult Index([FromQuery]int page = 1)
        {
            return View(_postService.GetAll(page = page));
        }

        //todo Blog indexdeki sayfalar < 1 2 3 > ile değişebilmeli
        //todo Departman ve tag ile post filtreleme eklenecek
        //todo comment ekleme eklenmeli

        public IActionResult Detail(int id)
        {
            var e = _postService.GetById(id);

			return View(e);
        }
    }
}
