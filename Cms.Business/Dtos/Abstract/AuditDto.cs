using System.ComponentModel.DataAnnotations;

namespace Cms.Business.Dtos.Abstract
{
    public abstract class AuditDto
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }
}