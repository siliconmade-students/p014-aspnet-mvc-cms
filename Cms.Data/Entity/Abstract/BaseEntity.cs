using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Entity.Abstract
{
    public abstract class BaseEntity : IAuiditEntity
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeletedAt { get; set; }
    }
}
