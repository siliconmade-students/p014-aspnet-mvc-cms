using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        public string Slug { get ; set; }

        public List<PostDto>? Posts { get; set; }

        public List<DoctorDto> Doctors { get; set; }
    }
}
