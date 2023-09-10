using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.SharedLibrary.File.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PostController : Controller
    {

        private readonly IPostService _postService;
        private readonly IDepartmentService _departmentService;
        private readonly IFileSaver _fileSaver;
        private readonly IWebHostEnvironment _env;

        public PostController(IPostService postService, IDepartmentService departmentService,IFileSaver fileSaver, IWebHostEnvironment env)
        {
            _postService = postService;
            _departmentService = departmentService;
            _fileSaver = fileSaver;
            _env = env;
        }


        // GET: PostController
        public async Task<IActionResult> Index()
        {
            return View(_postService.GetAll()); //todo pagination
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
            PostCreateViewModel vm = new()
            {
                Departments = _departmentService.GetAll().Select(e => new SelectListItem()
                {
                    Text = e.Name,
                    Value = e.Id.ToString(),
                }).ToList()
            };
            return View(vm);
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var imagePath = _fileSaver.SaveImage(vm.Image,_env+"images\\blog");

                PostImageDto dto = new PostImageDto
                {
                    CreatedAt = DateTime.Now,
                    ImagePath = imagePath,
                };
                var imgId =_postService.AddImage(dto); //şimdilik post service da kalsın ayırmaya zaman yok

                PostDto post = new()
                {
                    Content = vm.Content,
                    CreatedAt = DateTime.Now,
                    Title = vm.Title,
                    UserId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    PostImageDtoId = imgId,
                    Departments = new List<DepartmentDto>()
                    
                };
                if (vm.SelectedDepartments != null)
                {
                    foreach (var sd in vm.SelectedDepartments)
                    {
                        var department = _departmentService.GetById(sd);
                        post.Departments.Add(department);                   //çözemedim
                    }
                }

                _postService.Add(post);
                return Redirect("/Admin/Post");
            }

            return View(vm);
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
