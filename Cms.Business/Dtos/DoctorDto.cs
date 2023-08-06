using Cms.Data.Entity;
using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Dtos;

public class DoctorDto : BaseEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }

	public string? Content { get; set; }
	public DepartmentDto DepartmentDto { get; set; }
	public int DepartmentDtoId { get; set; }
}
