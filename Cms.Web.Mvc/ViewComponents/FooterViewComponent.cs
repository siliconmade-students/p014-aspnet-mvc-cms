using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		private readonly IDepartmentService _departmentService;
		private readonly ISettingService _settingService;

		public FooterViewComponent(IDepartmentService departmentService, ISettingService settingService)
		{
			_departmentService = departmentService;
			_settingService = settingService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var departments = _departmentService.GetAll();

			var settings = _settingService.GetAll();
			//Model.Settings.FirstOrDefault(e=>e.Name == SettingConstants.Telefon).Value;

			return View(new NavigationViewModel { Departments = departments, Settings = settings });
		}
	}
}
