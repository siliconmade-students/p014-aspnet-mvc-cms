using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public List<PostDto> GetAll(int page = 1)
		{
			var posts = _context.Posts.Skip((page-1)*10).Take(10).Include(e=> e.User).Include(e=>e.Departments).ToList();

			return _mapper.Map<List<PostDto>>(posts);
		}

        public List<PostDto> GetByDepartmentSlug(string slug ,int page = 1)
        {
            var posts = _context.Posts.Include(e => e.User).Include(e => e.Departments).Where(e=>e.Departments.Any(e=>e.Slug == slug)).Skip((page - 1) * 10).Take(10).ToList();

            return _mapper.Map<List<PostDto>>(posts);
        }
    }
}
