using Cms.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class PostComment : AuditEntity
    {
        public int? PostId { get; set; }

        public Post? Post { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        [Unicode, MaxLength(1000)]
        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
