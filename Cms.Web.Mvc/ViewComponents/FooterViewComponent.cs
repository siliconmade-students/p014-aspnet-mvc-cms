using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		private readonly IDepartmentService _departmentService;
		public FooterViewComponent(IDepartmentService departmentService)
		{
			_departmentService = departmentService;

		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			var departments = _departmentService.GetAll();

			return View(new NavigationViewModel { DepartmentDtos = departments });
		}
	}
}
