using System.ComponentModel.DataAnnotations.Schema;
using Cms.Data.Entity.Abstract;

namespace Cms.Data.Entity
{
    public class PostImage : BaseEntity
    {

        [Column(TypeName = "int")]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ImagePath { get; set; }
    }
}
