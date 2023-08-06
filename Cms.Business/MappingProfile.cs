using AutoMapper;
using Bogus.DataSets;
using Cms.Business.Dtos;
using Cms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ForMember(e => e.DepartmentDtoId, e => e.MapFrom(e2 => e2.DepartmentId));
            //CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}