using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Cms.Web.Mvc.Models.unused;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Cms.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public BlogController(IPostService postService,ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        public IActionResult Index([FromQuery] int page = 1)
        {
            return View(_postService.GetAll(page = page));
        }

        //todo Blog indexdeki sayfalar < 1 2 3 > ile değişebilmeli
        //todo Departman ve tag ile post filtreleme eklenecek
        //todo comment ekleme eklenmeli

        public IActionResult Detail(int id)
        {
            var post = MapToVm(_postService.GetById(id));
            
            return View(post);
        }

        [HttpPost]
        public IActionResult Detail(int id, BlogDetailViewModel vm)
        {
            var post = MapToVm(_postService.GetById(id));
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            //Comment ekleme işlemleri
            _commentService.Add(new() { Comment = vm.Comment, CreatedAt = DateTime.Now, IsActive = true, PostDtoId = id, UserDto = null });
            return View(post);
        }

        private BlogDetailViewModel MapToVm(PostDto post)
        {
            return new BlogDetailViewModel { User = post.User, Comments = post.Comments, Content = post.Content, CreatedAt = post.CreatedAt, Departments = post.Departments, PostImageDto = post.PostImageDto, Title = post.Title, UpdatedAt = post.UpdatedAt };
        }
    }
}
