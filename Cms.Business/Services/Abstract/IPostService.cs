using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
    public interface IPostService
    {
        List<PostDto> GetAll(int page = 1);
        PostDto GetById(int id);
        List<PostDto> GetByCategory(string categoryName, int page = 1);
        List<PostDto> GetByDepartmentSlug(string categoryName, int page = 1);


    }
}
