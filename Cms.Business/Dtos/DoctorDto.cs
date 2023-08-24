using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos;

public class DoctorDto : BaseDto
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public string? Content { get; set; }
    public DepartmentDto DepartmentDto { get; set; }
    public int DepartmentDtoId { get; set; }
	public string ImagePath { get; set; }
}
