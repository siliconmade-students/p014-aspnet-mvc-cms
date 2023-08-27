using AutoMapper;
using Azure;
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
        public List<PostDto> GetAll(int page = 1, string departmentSlug = null)
        {
            var posts = new List<Post>();
            if (departmentSlug != null)
            {
                posts = _context.Posts.Where(p => p.Departments.Any(d => d.Slug == departmentSlug)).Skip((page - 1) * 10).Take(10).Include(e => e.User).Include(e => e.Departments).Include(e => e.PostImage).Include(e => e.Comments).ToList();
            }
            else
            {
                posts = _context.Posts.Skip((page - 1) * 10).Take(10).Include(e => e.User).Include(e => e.Departments).Include(e => e.PostImage).Include(e => e.Comments).ToList();
            }

            return _mapper.Map<List<PostDto>>(posts);
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

        public int GetMaxPageCount(string searchQuery = null,bool queryIsDepartment = false)
        {
            var posts = new List<Post>();
            if(searchQuery == null) { 
                posts = _context.Posts.ToList();
            }else if(queryIsDepartment = true)
            {
                posts = _context.Posts.Include(e=>e.Departments).Where(e=>e.Departments.Any(e=>e.Slug == searchQuery)).ToList();
            }
            else
            {
                posts = _context.Posts.Where(e=>e.Title.Contains(searchQuery)).ToList();
            }

            if(posts.Count/10f - posts.Count/10 != 0) { 
            return posts.Count/10+1;
            }
            return posts.Count/10;
        }
    }
}
