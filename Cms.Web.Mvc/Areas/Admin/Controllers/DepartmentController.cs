using Cms.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Business.Dtos;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            return View(_departmentService.GetAll());
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();


            return View(department);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Add(department);
                return Redirect("/Admin/Department");
            }
            return View(department);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null) return NotFound();

            return View(department);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentDto department)
        {
            var succeeded = _departmentService.Update(id, department);
            if (!succeeded)
                return View(department);
            return Redirect("/Admin/Department");
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null) return NotFound();
            return View(department);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _departmentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
