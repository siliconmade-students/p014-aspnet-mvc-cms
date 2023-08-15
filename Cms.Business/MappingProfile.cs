using AutoMapper;
using Cms.Business.Dtos;
using Cms.Data.Entity;

namespace Cms.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Appoinment, AppoinmentDto>().ForMember(e => e.DepartmentDtotId, e => e.MapFrom(e2 => e2.DepartmentId)).ForMember(e => e.DoctorDtoId, e => e.MapFrom(e2 => e2.DoctorId)).ReverseMap();


			CreateMap<Doctor, DoctorDto>().ForMember(e => e.DepartmentDtoId, e => e.MapFrom(e2 => e2.DepartmentId));
            //CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}