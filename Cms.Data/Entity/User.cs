using Cms.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Data.Entity
{
    public class User : AuditEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        public string? Roles { get; set; }
    }
}
