using Cms.Data.Entity.Abstract;

namespace Cms.Data.Entity
{
    public class Doctor : AuditEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string? Content { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }

        public string ImagePath { get; set; }
    }
}
