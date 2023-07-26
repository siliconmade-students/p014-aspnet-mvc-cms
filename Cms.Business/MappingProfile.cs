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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            //CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}