using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class DoctorCreateOrEditViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Content { get; set; }
        public List<SelectListItem>? Departments { get; set; }
        public int DepartmentId { get; set; }

        public IFormFile Image { get; set; }
    }
}
