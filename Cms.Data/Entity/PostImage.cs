using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class PostImage : AuditEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        [MaxLength(400)]
        public string ImagePath { get; set; }
    }
}
