using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cms.Data;
using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Cms.Business.Services.Abstract;
using Cms.Business.Dtos;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		// GET: Admin/User
		public async Task<IActionResult> Index()
        {
            return View(_userService.GetAll());
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return RedirectToAction(nameof(Index));
            return View(user);
        }

        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDto dto)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(dto);
            return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
			var user = _userService.GetById(id);
			if (user == null) return RedirectToAction(nameof(Index));
			return View(user);
		}

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserDto dto)
        {
            var user = _userService.GetById(id);
            if(user == null) return RedirectToAction(nameof(Index));

			if (ModelState.IsValid)
            {
                _userService.Update(id, dto);
				return RedirectToAction(nameof(Index));
			}
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return RedirectToAction(nameof(Index));
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
