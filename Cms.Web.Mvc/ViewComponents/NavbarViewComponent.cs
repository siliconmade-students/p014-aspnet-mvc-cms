using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cms.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IDepartmentService _categoryService;
        private readonly IDoctorService _doctorService;
        public NavbarViewComponent(IDepartmentService categoryService, IDoctorService doctorService)
        {
            _categoryService = categoryService;
            _doctorService = doctorService;

		}


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = _categoryService.GetAll();
            var doctors = _doctorService.GetAll();

            return View(new NavbarViewModel { DepartmentDtos = departments, DoctorDtos = doctors});
        }
    }
}
