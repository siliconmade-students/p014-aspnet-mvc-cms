using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;
        private readonly IAppoinmentService _appoinmentService;

        public AppointmentController(IDoctorService doctorService, IDepartmentService departmentService, IAppoinmentService appoinmentService)
        {
            _doctorService = doctorService;
            _departmentService = departmentService;
            _appoinmentService = appoinmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAll()
                .Select(e => new SelectListItem
                {
                    Value = Convert.ToString(e.Id),
                    Text = e.Name
                })
                .ToList();

            return View(new AppointmentViewModel { Departments = departments });
        }

        [HttpPost]
        public IActionResult Index(AppointmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.GetAll()
                .Select(e => new SelectListItem
                {
                    Value = Convert.ToString(e.Id),
                    Text = e.Name
                })
                .ToList();
                vm.Departments = departments;

                return View(vm);
            }
            _appoinmentService.Create(new() { DepartmentDtotId = vm.Department, DoctorDtoId = vm.Doctor, Date = vm.Date, Time = vm.Time, Name = vm.Name, phoneNumber = vm.phoneNumber, Email = vm.Email, Content = vm.Content });


            return RedirectToAction(nameof(Confirmation));
        }


        public IActionResult Confirmation() => View();


        [HttpGet]
        [Route("{controller}/GetDoctors/{id}")]
        public IActionResult GetDoctorsByDepartment(int id)
        {
            var doctorList = _doctorService.GetByDepartmentId(id).Select(e => new SelectListItem { Text = e.Name + " " + e.Surname, Value = e.Id.ToString() });
            return Json(doctorList);
        }
    }
}
