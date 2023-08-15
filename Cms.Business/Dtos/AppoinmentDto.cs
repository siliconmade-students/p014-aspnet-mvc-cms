using Cms.Business.Dtos.Abstract;
using Cms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Dtos
{
	public class AppoinmentDto : AuditDto
	{
		public int DepartmentDtotId { get; set; }
		public DepartmentDto? Department { get; set; }
		public int DoctorDtoId { get; set; }
		public DoctorDto? Doctor { get; set; }
		public string Date { get; set; }
		public string Time { get; set; }
		public string Name { get; set; }
		public string phoneNumber { get; set; }
		public string Email { get; set; }
		public string Content { get; set; }
	}
}
