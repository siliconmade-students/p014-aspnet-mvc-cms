using Cms.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Entity
{
    public class PostComment : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        [Column(TypeName = "int")]
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
