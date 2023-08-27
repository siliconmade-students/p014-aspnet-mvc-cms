using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
    public class BlogSidebarViewComponent : ViewComponent
    {
        private IDepartmentService _departmentService;

        public BlogSidebarViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
    }
}
