using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        // GET: PostController
        public async Task<IActionResult> Index()
        {
            return View(_postService.GetAll());
        }

        // GET: PostController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
                return NotFound();


            return View(post);
        }

        // GET: PostController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostDto post)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(post);
                return Redirect("/Admin/Post");
            }
            return View(post);
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();

            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostDto post)
        {
            var succeeded = _postService.Update(id, post);
            if (!succeeded)
                return View(post);
            return Redirect("/Admin/Post");
        }

        // GET: PostController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();
            return View(post);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _postService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
