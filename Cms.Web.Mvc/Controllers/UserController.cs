using Cms.Business.Dtos;
using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		private readonly IUserService _userService; //todo user profil sayfası validation eksik

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			var user = _userService.GetById(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

			return View(new UserSettingsViewModel()
			{
				Email = user.Email,
				City = user.City,
				Name = user.Name,
				Password = user.Password,
				Phone = user.Phone,
				Surname = user.Surname,
			});
		}
		[HttpPost]
		public IActionResult Index(UserSettingsViewModel vm)
		{
			var user = new UserDto()
			{
				City = vm.City,
				Name = vm.Name,
				Password = vm.Password,
				Phone = vm.Phone,
				Surname = vm.Surname,
				Email = vm.Email
			};
			var succeded = _userService.Update(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value), user);
			if (!succeded) ViewBag.Error = "Bilinmeyen bir hata ile karşılaşıldı";
			return View();
		}
	}
}
