using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity.Abstract
{
    public abstract class AuditEntity : BaseEntity, IAuditEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }
}
