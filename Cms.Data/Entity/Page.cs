using Cms.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class Page : AuditEntity
    {
        [Unicode, MaxLength(200)]
        public string Title { get; set; }

        [Unicode]
        public string Content { get; set; }

        public bool IsActive { get; set; }
    }
}
