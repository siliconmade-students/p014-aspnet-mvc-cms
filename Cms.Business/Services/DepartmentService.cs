using AutoMapper;
using Cms.Business.Services.Abstract;
using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Data;

namespace Cms.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DepartmentDto> GetAll()
        {
            var entities = _context.Departments.ToList();

            return _mapper.Map<List<DepartmentDto>>(entities);
        }

        public DepartmentDto GetById(int id)
        {
            var entity = _context.Departments.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<DepartmentDto>(entity);
        }
		public DepartmentDto GetByDepartmentSlug(string slug)
        {
			var entity = _context.Departments.FirstOrDefault(e => e.Slug == slug);

			return _mapper.Map<DepartmentDto>(entity);
		}
	}
}
