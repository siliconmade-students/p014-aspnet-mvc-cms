using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
    public interface IPageService
    {
        void Delete(int id);
        List<PageDto> GetAll();
        PageDto GetById(int id);
        PageDto GetBySlug(string slug);
        bool Update(int id, PageDto page);

        void Add(PageDto page);
    }
}
