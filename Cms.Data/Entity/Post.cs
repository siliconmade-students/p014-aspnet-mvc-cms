using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Data.Entity
{
    public class Post : AuditEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public List<Category>? Categories { get; set; }
        public List<Department>? Departments { get; set; }
        public List<PostComment>? Comments { get; set; }

        public int PostImageId { get; set; }
        public PostImage? PostImage { get; set; } 

    }
}
