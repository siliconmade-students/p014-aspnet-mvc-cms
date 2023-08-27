using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cms.Data;
using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Cms.Web.Mvc.Areas.Admin.ViewModels; // PostViewModel'ı eklemeyi unutmayın
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Post
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.ToListAsync();
            return View(posts);
        }

        // GET: Admin/Post/Create
        public async Task<IActionResult> CreateAsync()
        {
            // PostViewModel'ı oluşturup gerekli verileri doldurun
            var viewModel = new PostViewModel
            {
                AllCategories = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Admin/Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // PostViewModel'den gerekli alanları kullanarak Post oluşturun
                var post = new Post
                {
                    Title = viewModel.Title,
                    Content = viewModel.Content,
                    // Diğer alanları doldurun
                };

                // Kategorileri eklemeyi unutmayın
                foreach (var categoryId in viewModel.SelectedCategories)
                {
                    var category = await _context.Categories.FindAsync(categoryId);
                    if (category != null)
                    {
                        post.Categories.Add(category);
                    }
                }

                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ModelState geçerli değilse, viewModel içindeki verileri düzgün bir şekilde almak için
            viewModel.AllCategories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        // Diğer action'ları benzer şekilde düzenleyin

        // ... Edit, Delete ve diğer action'lar

        // Diğer yardımcı metotları benzer şekilde düzenleyin

        // ... UserExists ve diğer yardımcı metotlar
    }
}
