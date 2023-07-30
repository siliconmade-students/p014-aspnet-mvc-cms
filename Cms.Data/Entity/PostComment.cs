using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Data.Entity
{
    public class PostComment : BaseEntity
    {
        public int? PostId { get; set; }

        public Post? Post { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
