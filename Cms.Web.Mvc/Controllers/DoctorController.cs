using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
	public class DoctorController : Controller
	{
		private readonly IDoctorService _doctorService;
		private readonly IDepartmentService _departmentService;

		public DoctorController(IDoctorService doctorService, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
			_departmentService = departmentService;
        }
        public IActionResult Index()
		{
			return View(new DoctorViewModel { Doctors = _doctorService.GetAll() ,Departments= _departmentService.GetAll()});
		}
		[Route("doctor/{id}")]
		public IActionResult Single(int id)
		{
			var a = _doctorService.GetById(id);
			return View(a);
		}
	}
}
