using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Dtos
{
    public class PostDto : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public UserDto User { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        public string Content { get; set; }

        public List<DepartmentDto>? Departments { get; set; }
    }
}
