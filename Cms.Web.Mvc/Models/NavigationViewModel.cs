using Cms.Business.Dtos;

namespace Cms.Web.Mvc.Models
{
	public class NavigationViewModel
	{
		public List<DepartmentDto> Departments { get; set; }
		public List<DoctorDto> Doctors { get; set; }
		public List<SettingDto> Settings { get; internal set; }
	}
}
