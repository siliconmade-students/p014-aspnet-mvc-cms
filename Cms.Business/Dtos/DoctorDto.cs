using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Dtos;

public class DoctorDto : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
