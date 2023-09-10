using Cms.Business.Dtos;
using Cms.Data.Entity;
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
        int GetAllNo();
        DepartmentDto GetByDepartmentSlug(string slug);
        DepartmentDto GetById(int id);

        void Add(DepartmentDto department);

        bool Update(int id, DepartmentDto department);

        void Delete(int id);
    }
}
