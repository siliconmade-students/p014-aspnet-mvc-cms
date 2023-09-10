using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {


        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly IPostService _postService;
        private readonly IDoctorService _doctorService;

        public HomeController(IUserService userService, IDepartmentService departmentService, IPostService postService, IDoctorService doctorService)
        {
            _userService = userService;
            _departmentService = departmentService;
            _postService = postService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            ViewBag.userNumber = _userService.GetAllNo();
            ViewBag.departmanNumber = _departmentService.GetAllNo();
            ViewBag.postNumber = _postService.GetAllNo();
            ViewBag.doctorNumber = _doctorService.GetAllNo();

            return View();

        }



    }
}
