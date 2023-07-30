using Cms.Data.Entity.Abstract;

namespace Cms.Data.Entity
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
