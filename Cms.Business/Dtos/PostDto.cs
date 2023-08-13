using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class PostDto : AuditDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<DepartmentDto>? Departments { get; set; }
    }
}
