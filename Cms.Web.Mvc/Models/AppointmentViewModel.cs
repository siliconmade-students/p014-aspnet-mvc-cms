using Cms.Business.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Models
{
	public class AppointmentViewModel
	{
		[ValidateNever]
		public List<SelectListItem> Departments { get; set; }
		public int Department { get; set; }

		public int Doctor { get; set; }

		[Required]
		public string Date { get; set; }

		[Required]
		public string Time { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string phoneNumber { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Content { get; set; }
	}
}
