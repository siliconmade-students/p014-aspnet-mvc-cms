using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Data.Entity
{
    public class Page : AuditEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
