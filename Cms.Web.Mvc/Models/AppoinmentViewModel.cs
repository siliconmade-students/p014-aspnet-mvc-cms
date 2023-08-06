using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cms.Web.Mvc.Models
{
	public class AppoinmentViewModel
	{
		public IEnumerable<DoctorSelectListModel> Doctors { get; set; }
		public IEnumerable<SelectListItem> Departments { get; set; }
	}
}
