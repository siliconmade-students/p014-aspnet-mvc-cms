using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Data.Entity
{
    public class Setting : BaseEntity
    {
        //public int? UserId { get; set; }
        //public User? User { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(400)")]
        public string Value { get; set; }
    }
}
