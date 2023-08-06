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

        public DoctorDto GetById(int id)
        {
            var entity = _context.Doctors.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<DoctorDto>(entity);
        }
    }
}
