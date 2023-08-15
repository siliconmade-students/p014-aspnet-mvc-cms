using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Entity
{
	public class Appoinment : AuditEntity
	{
		public int DepartmentId { get; set; }
		public Department? Department { get; set; }
		public int DoctorId { get; set; }
		public Doctor? Doctor { get; set; }
		public string Date { get; set; }
		public string Time { get; set; }
		public string Name { get; set; }
		public string phoneNumber { get; set; }
		public string Email { get; set; }
		public string Content { get; set; }
	}
}
