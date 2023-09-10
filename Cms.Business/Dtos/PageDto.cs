using Cms.Business.Dtos.Abstract;
using Cms.Data.Entity;

namespace Cms.Business.Dtos
{
    public class PageDto : AuditDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }

        
    }
}
