using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class DepartmentDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

		public string Content { get; set; }

		public string Slug { get; set; }
		public string CoverImagePath { get; set; }

		public List<PostDto>? Posts { get; set; }

        public List<DoctorDto> Doctors { get; set; }
    }
}
