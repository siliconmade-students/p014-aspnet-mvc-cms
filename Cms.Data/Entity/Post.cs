using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Entity
{
    public class Post : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int UserId { get; set; } 
        public User User { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public List<Department>? Departments { get; set; }
    }
}
