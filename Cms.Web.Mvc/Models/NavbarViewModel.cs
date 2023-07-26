using Cms.Business.Dtos;

namespace Cms.Web.Mvc.Models
{
    public class NavbarViewModel
    {
        public List<CategoryDto> CategoryDtos { get; set; }
        public List<DoctorDto> DoctorDtos { get; set;}
    }
}
