using AutoMapper;
using Cms.Business.Services.Abstract;
using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Data;
using Microsoft.EntityFrameworkCore;
using Cms.Data.Entity;

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
            var entities = _context.Departments.Include(e=>e.Posts).Include(e=>e.Doctors).ToList();

            return _mapper.Map<List<DepartmentDto>>(entities);
        }

        public int GetAllNo()
        {
            return _mapper.Map<List<DepartmentDto>>(_context.Departments.ToList()).Count();
        }

        public DepartmentDto GetById(int id)
        {
            var entity = _context.Departments.Include(e => e.Posts).Include(e => e.Doctors).FirstOrDefault(e => e.Id == id);

            return _mapper.Map<DepartmentDto>(entity);
        }
        public DepartmentDto GetByDepartmentSlug(string slug)
        {
            var entity = _context.Departments.FirstOrDefault(e => e.Slug == slug);

			return _mapper.Map<DepartmentDto>(entity);
		}

        public void Add(DepartmentDto department)
        {
            _context.Add(_mapper.Map<Department>(department));
            _context.SaveChanges();
        }

        public bool Update(int id, DepartmentDto department)
        {
            var oldDepartment = _context.Departments.Find(id);

            if (oldDepartment is null) return false;

            //oldDepartment = _mapper.Map<Department>(department);
            oldDepartment.Name = department.Name;
            oldDepartment.Slug = department.Slug;
            oldDepartment.Content = department.Content;
            oldDepartment.Description = department.Description;
            _context.SaveChanges();

            return true;
        }
        public void Delete(int id)
        {
            var department= _context.Departments.Find(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}
