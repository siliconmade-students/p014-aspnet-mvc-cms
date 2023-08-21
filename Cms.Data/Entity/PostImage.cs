using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class PostImage : AuditEntity
    {
        [MaxLength(400)]
        public string ImagePath { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
