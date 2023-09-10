using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
    public class PostCreateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }


        public List<SelectListItem>? Departments { get; set; }
        public List<int>? SelectedDepartments { get; set; }

        public IFormFile Image { get; set; }
    }
}
