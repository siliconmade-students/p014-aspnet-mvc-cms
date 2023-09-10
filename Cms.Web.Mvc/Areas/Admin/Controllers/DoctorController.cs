using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data.Entity;
using Cms.SharedLibrary.File.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IFileSaver _fileSaver;
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _env;

        public DoctorController(IDoctorService doctorService, IFileSaver fileSaver, IDepartmentService departmentService, IWebHostEnvironment env)
        {
            _doctorService = doctorService;
            _fileSaver = fileSaver;
            _departmentService = departmentService;
            _env = env;
        }

        public IActionResult Index()
        {

            return View(_doctorService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
                return NotFound();


            return View(doctor);
        }


        public IActionResult Create()
        {
            DoctorCreateViewModel model = new DoctorCreateViewModel();
            model.Departments = _departmentService.GetAll().Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString(),
            }).ToList();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var path = _env.WebRootPath + "\\images\\team";
                var filePath = _fileSaver.SaveImage(vm.Image, path);

                DoctorDto doctor = new DoctorDto()
                {
                    Content = vm.Content,
                    DepartmentDtoId = vm.DepartmentId,
                    ImagePath = filePath,
                    Name = vm.Name,
                    Surname = vm.Surname,
                };
                _doctorService.Add(doctor);
                return RedirectToAction(nameof(Index));
            }
            vm.Departments = _departmentService.GetAll().Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString(),
            }).ToList();
            return View(vm);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorDto doctor)
        {
            var succeeded = _doctorService.Update(id, doctor);
            if (!succeeded)
                return View(doctor);
            return Redirect("/Admin/Doctor");
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _doctorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
