using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data.Utility;
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
			var posts = _context.Posts.Skip((page-1)*10).Take(10).Include(e=> e.User).Include(e=>e.Categories).ToList();

			return _mapper.Map<List<PostDto>>(posts);
		}

        public List<PostDto> GetByCategory(string categoryName ,int page = 1)
        {
            var posts = _context.Posts.Include(e => e.User).Include(e => e.Categories).Where(e=>e.Categories.Any(e=>e.Name.ToLower() == categoryName.ToLower())).Skip((page - 1) * 10).Take(10).ToList();

            return _mapper.Map<List<PostDto>>(posts);
        }
    }
}
