using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cms.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cms.Data.Entity
{
    public class Department : BaseEntity
    {
        [Unicode, MaxLength(100)]
        public string Name { get; set; }

        [Unicode, MaxLength(200)]
        public string Description { get; set; }
    }
}
