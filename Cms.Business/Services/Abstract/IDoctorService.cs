using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services.Abstract
{
	public interface IDoctorService
	{
		List<DoctorDto> GetAll();
		int GetAllNo();
		DoctorDto GetById(int id);
		List<DoctorDto> GetByDepartmentId(int departmentId);
		void Delete(int id);
		void Add(DoctorDto doctor);
		bool Update(int id, DoctorDto doctor);
	}
}
