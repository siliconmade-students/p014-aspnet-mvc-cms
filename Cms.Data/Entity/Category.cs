using Cms.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cms.Data.Entity
{
    public class Category : BaseEntity
    {
        [Unicode, MaxLength(100)]
        public string Name { get; set; }

        [Unicode, MaxLength(200)]
        public string Description { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
