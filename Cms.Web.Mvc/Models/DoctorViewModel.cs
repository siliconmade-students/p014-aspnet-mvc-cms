using Cms.Business.Dtos;

namespace Cms.Web.Mvc.Models
{
	public class DoctorViewModel
	{
		public List<DoctorDto> Doctors { get; set; }
		public List<DepartmentDto> Departments { get; set; }
	}
}
