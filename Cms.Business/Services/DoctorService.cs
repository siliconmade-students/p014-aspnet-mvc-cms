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
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DoctorDto> GetAll()
        {
            var entities = _context.Doctors.Include(e => e.Department).ToList();

            return _mapper.Map<List<DoctorDto>>(entities);
        }

        public int GetAllNo()
        {
            return _mapper.Map<List<DoctorDto>>(_context.Doctors.ToList()).Count();
        }

        public DoctorDto GetById(int id)
        {
            var entity = _context.Doctors.Include(e => e.Department).FirstOrDefault(e => e.Id == id);

            return _mapper.Map<DoctorDto>(entity);
        }
		public List<DoctorDto> GetByDepartmentId(int id)
		{
			var entities = _context.Doctors.Where(e => e.DepartmentId == id).Include(e => e.Department).ToList();

			return _mapper.Map<List<DoctorDto>>(entities);
		}

        public void Delete(int id)
        {
            var a = _context.Doctors.Find(id);
            _context.Doctors.Remove(a);
            _context.SaveChanges();
        }

        public void Add(DoctorDto doctor)
        {
           _context.Add(_mapper.Map<Doctor>(doctor));
            _context.SaveChanges();
        }

        public bool Update(int id, DoctorDto doctor)
        {
            var oldDoctor = _context.Doctors.Find(id);

            if (oldDoctor is null) return false;

            //oldDepartment = _mapper.Map<Department>(department);
            oldDoctor.Id = id;
            oldDoctor.Name = doctor.Name;
            oldDoctor.UpdatedAt = DateTime.Now;
            oldDoctor.DepartmentId = doctor.DepartmentDtoId;
            oldDoctor.Content = doctor.Content;
            oldDoctor.ImagePath = doctor.ImagePath;
            oldDoctor.Surname = doctor.Surname;

            _context.SaveChanges();

            return true;
        }
    }
}
