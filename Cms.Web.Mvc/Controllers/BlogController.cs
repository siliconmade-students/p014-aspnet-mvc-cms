using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Controllers
{
	public class BlogController : Controller
	{
		private readonly IPostService _postService;
		private readonly ICommentService _commentService;
		private readonly IDepartmentService _departmentService;

		public BlogController(IPostService postService, ICommentService commentService, IDepartmentService departmentService)
		{
			_postService = postService;
			_commentService = commentService;
			_departmentService = departmentService;
		}

		public IActionResult Index(int page = 1, string? departman = null)
		{
			int maxPage = _postService.GetMaxPageCount(departman, true);
			if (page > maxPage)
			{
				return Redirect("Blog?page=" + maxPage + "&departman=" + departman);
			}
			else if (page < 1)
			{
				return Redirect("Blog?page=" + 1 + "&departman=" + departman);
			}
			var departmanDto = new DepartmentDto();
			if (departman != null)
			{
				departmanDto = _departmentService.GetByDepartmentSlug(departman);
				ViewBag.departman = departmanDto;
			}
			ViewBag.currentPage = page;
			ViewBag.maxPage = maxPage;
			return View(_postService.GetAll(page, departmanDto.Slug));
		}


		public IActionResult Detail(int id)
		{
			var post = MapToVm(_postService.GetById(id));

			return View(post);
		}

		[HttpPost]
		public IActionResult Detail(int id, BlogDetailViewModel vm)
		{
			var post = new BlogDetailViewModel();
			if (ModelState.IsValid)
			{
				var comment = new PostCommentDto { Comment = vm.Comment, CreatedAt = DateTime.Now, IsActive = true, PostDtoId = id, UserDto = null };
				if (HttpContext.User.Identity.IsAuthenticated)
				{
					comment.UserDtoId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
				}

				_commentService.Add(comment);
			}

			post = MapToVm(_postService.GetById(id));
			post.Comment = vm.Comment;
			return RedirectToAction(nameof(Detail));
		}

		private BlogDetailViewModel MapToVm(PostDto post)
		{
			return new BlogDetailViewModel { User = post.User, Comments = post.Comments, Content = post.Content, CreatedAt = post.CreatedAt, Departments = post.Departments, PostImageDto = post.PostImageDto, Title = post.Title, UpdatedAt = post.UpdatedAt };
		}
	}
}
