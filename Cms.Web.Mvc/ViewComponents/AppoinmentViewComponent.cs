using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace Cms.Web.Mvc.ViewComponents
{
	public class AppoinmentViewComponent : ViewComponent
	{
		private readonly IDepartmentService _departmentService;
		private readonly IDoctorService _doctorService;
		public AppoinmentViewComponent(IDepartmentService departmentService, IDoctorService doctorService)
		{
			_departmentService = departmentService;
			_doctorService = doctorService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var doctors = _doctorService.GetAll();
			return View(new AppoinmentViewModel {
				Departments = _departmentService
				.GetAll()
				.Select(e => new SelectListItem { Value = Convert.ToString(e.Id), Text = e.Name })
				.ToList()

				, Doctors = doctors
				.Select(e => new DoctorSelectListModel { Value = Convert.ToString(e.Id), Text = e.Name + " " + e.Surname ,DepartmentId = Convert.ToString(e.DepartmentDtoId)})
				.ToList()
			});
		}
	}
}
