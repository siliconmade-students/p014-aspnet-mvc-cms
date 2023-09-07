using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetAll();
        DepartmentDto GetById(int id);
        DepartmentDto GetByDepartmentSlug(string slug);

        void Add(DepartmentDto department);
        bool Update(int id, DepartmentDto department);
        void Delete(int id);    

	}
}
