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

			CreateMap<User, UserDto>().ReverseMap();

			CreateMap<PostComment, PostCommentDto>()
				.ForMember(e => e.UserDtoId, e => e.MapFrom(e2 => e2.UserId))
				.ForMember(e => e.UserDto, e => e.MapFrom(e2 => e2.User))
				.ForMember(e => e.PostDtoId, e => e.MapFrom(e2 => e2.PostId))
				.ForMember(e => e.PostDto, e => e.MapFrom(e2 => e2.Post))
				.ReverseMap();

			CreateMap<PostImage, PostImageDto>().ReverseMap();

			CreateMap<Post, PostDto>()
				.ForMember(e => e.PostImageDto, e => e.MapFrom(e2 => e2.PostImage))
				.ReverseMap();

			CreateMap<Appoinment, AppoinmentDto>()
				.ForMember(e => e.DepartmentDtotId, e => e.MapFrom(e2 => e2.DepartmentId))
				.ForMember(e => e.DoctorDtoId, e => e.MapFrom(e2 => e2.DoctorId))
				.ReverseMap();

			CreateMap<Doctor, DoctorDto>()
				.ForMember(e => e.DepartmentDtoId, e => e.MapFrom(e2 => e2.DepartmentId))
				.ForMember(e => e.DepartmentDto, e => e.MapFrom(e2 => e2.Department))
				.ReverseMap();

			CreateMap<Page, PageDto>().ReverseMap();
			CreateMap<Setting, SettingDto>().ReverseMap();
		}
	}
}