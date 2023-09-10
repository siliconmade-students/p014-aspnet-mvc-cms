using Cms.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class DoctorCreateViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Content { get; set; }
        public List<SelectListItem>? Departments { get; set; }
        public int DepartmentId { get; set; }

        public IFormFile Image { get; set; }
    }
}
