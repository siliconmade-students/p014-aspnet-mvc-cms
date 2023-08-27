using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
    public class PageDto : AuditDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
