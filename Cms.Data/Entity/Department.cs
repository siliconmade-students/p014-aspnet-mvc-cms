using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class Department : AuditEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public string Slug { get; set; }
        public string CoverImagePath { get; set; }

        public List<Post>? Posts { get; set; }
        public List<Doctor>? Doctors { get; set; }
    }
}
