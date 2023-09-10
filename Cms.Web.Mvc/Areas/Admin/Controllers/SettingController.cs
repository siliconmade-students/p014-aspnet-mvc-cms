using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            var settings = _settingService.GetAll();
            return View(settings);
        }
        public IActionResult Details(int id)
        {
            var department = _settingService.GetById(id);
            if (department == null)
                return RedirectToAction(nameof(Index));


            return View(department);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingDto setting)
        {
            if (ModelState.IsValid)
            {
                _settingService.Add(setting);
                return Redirect("/Admin/Setting");
            }
            return View(setting);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var setting = _settingService.GetById(id);
            if (setting == null) return RedirectToAction(nameof(Index));

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingDto setting)
        {
            var succeeded = _settingService.Update(id, setting);
            if (!succeeded)
                return View(setting);
            return Redirect("/Admin/Setting");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var setting = _settingService.GetById(id);
            if (setting == null) return RedirectToAction(nameof(Index));
            return View(setting);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _settingService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
