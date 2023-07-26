using AutoMapper;
using Cms.Business.Services.Abstract;
using Cms.Business.Dtos;
using Cms.Data.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CategoryDto> GetAll()
        {
            var entities = _context.Categories.ToList();

            return _mapper.Map<List<CategoryDto>>(entities);
        }

        public CategoryDto GetById(int id)
        {
            var entity = _context.Categories.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
