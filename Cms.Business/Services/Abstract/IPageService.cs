using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
    public interface IPageService
    {
        List<PageDto> GetAll();
        PageDto GetById(int id);
        bool Update(int id, PageDto page);
        void Delete(int id);
    }
}
