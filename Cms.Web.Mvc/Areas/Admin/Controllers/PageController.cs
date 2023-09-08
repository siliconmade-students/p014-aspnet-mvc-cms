using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IMapper _mapper;

        public PageController(IPageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(_pageService.GetAll());

        }
        public IActionResult Create()
        {
            return View();
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var page = _pageService.GetById(id);
            if (page == null) return NotFound();

            return View(page);
        }
        public async Task<IActionResult> Edit(int id, PageDto page) //todo slug ve content için de inputlar oluşturulacak
        {
            var succeeded = _pageService.Update(id, page);
            if (!succeeded)
                return View(page);
            return Redirect("/Admin/Page");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var page = _pageService.GetById(id);
            if (page == null) return NotFound();
            return View(page);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Name,Slug,Content")] PageDto page)
        {

            _pageService.Delete(id);
            return RedirectToAction(nameof(Index));

            //if (id != page.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _pageService.Delete(id, page);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        /*
            //        if (!CategoryExists(category.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //        */
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(page);
        }
    }
}
