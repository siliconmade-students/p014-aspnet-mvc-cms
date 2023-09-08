using Cms.Business.Dtos.Abstract;
using Cms.Data.Entity;

namespace Cms.Business.Dtos
{
    public class PostDto : AuditDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        
        public List<DepartmentDto>? Departments { get; set; }
        public List<PostCommentDto> Comments { get; set; }

        public int PostImageDtoId { get; set; }
        public PostImageDto? PostImageDto { get; set; }
    }
}
