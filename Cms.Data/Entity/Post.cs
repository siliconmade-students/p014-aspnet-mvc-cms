using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class Post : AuiditEntity
    {
        [Column(TypeName = "int")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
