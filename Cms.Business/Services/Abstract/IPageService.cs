using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
    public interface IPageService
    {
        List<PageDto> GetAll();
        PageDto GetById(int id);
    }
}
