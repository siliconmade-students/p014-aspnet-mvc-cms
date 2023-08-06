using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cms.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IDepartmentService _departmentService;
        public NavbarViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

		}


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = _departmentService.GetAll();

            return View(new NavigationViewModel { DepartmentDtos = departments});
        }
    }
}
