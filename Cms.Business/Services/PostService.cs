using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Cms.Business.Services
{
	public class PostService : IPostService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public PostService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public List<PostDto> GetAll(int page = 1, string? departmentSlug = null)
		{
			var posts = _context.Posts
				.Include(e => e.User)
				.Include(e => e.Departments)
				.Include(e => e.PostImage)
				.Include(e => e.Comments)
				.Select(e => e);

			if (departmentSlug != null)
			{
				posts = posts.Where(p => p.Departments.Any(d => d.Slug == departmentSlug));
			}

			var postList = posts.Skip((page - 1) * 10).Take(10).ToList();

			return _mapper.Map<List<PostDto>>(postList);
		}

        public int GetAllNo()
        {
            return _mapper.Map<List<PostDto>>(_context.Posts.ToList()).Count();
        }

        public PostDto GetById(int id)
		{
			return _mapper.Map<PostDto>(
				_context.Posts.Include(e => e.User).Include(e => e.Departments).Include(e => e.PostImage).Include(e => e.Comments).ThenInclude(c => c.User).FirstOrDefault(e => e.Id == id)
				);
		}

		public List<PostDto> GetByDepartmentSlug(string slug, int page = 1)
		{
			var posts = _context.Posts.Include(e => e.User).Include(e => e.Departments).Where(e => e.Departments.Any(e => e.Slug == slug)).Skip((page - 1) * 10).Take(10).ToList();

			return _mapper.Map<List<PostDto>>(posts);
		}

		public List<PostDto> GetByCategory(string categoryName, int page = 1)
		{
			var posts = _context.Posts
				.Include(e => e.User).Include(e => e.Categories)
				.Where(e => e.Categories.Any(e => e.Name.ToLower() == categoryName.ToLower()))
				.Skip((page - 1) * 10)
				.Take(10)
				.ToList();

			return _mapper.Map<List<PostDto>>(posts);
		}

		public int GetMaxPageCount(string searchQuery = null, bool queryIsDepartment = false)
		{
			var posts = new List<Post>();
			if (searchQuery == null)
			{
				posts = _context.Posts.ToList();
			}
			else if (queryIsDepartment == true)
			{
				posts = _context.Posts.Include(e => e.Departments).Where(e => e.Departments.Any(e => e.Slug == searchQuery)).ToList();
			}
			else
			{
				posts = _context.Posts.Where(e => e.Title.Contains(searchQuery)).ToList();
			}

			return (int)Math.Ceiling(posts.Count / 10m);
		}

		public void Add(PostDto post)
		{
			_context.Add(_mapper.Map<Post>(post));
			_context.SaveChanges();
		}

		public bool Update(int id, PostDto post)
		{
			var oldPost = _context.Posts.Find(id);

			if (oldPost is null) return false;

			//oldPost = _mapper.Map<Department>(post);
			oldPost.Title = post.Title;
			
			oldPost.Content = post.Content;
			_context.SaveChanges();

			return true;
		}
		public void Delete(int id)
		{
			var post = _context.Posts.Find(id);
			_context.Posts.Remove(post);
			_context.SaveChanges();
		}

        public int AddImage(PostImageDto dto)
        {
            _context.PostImages.Add(_mapper.Map<PostImage>(dto));
            _context.SaveChanges();
            return dto.Id;
        }
    }
}
