using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
	public interface ISettingService
	{
		List<SettingDto> GetAll();
        SettingDto GetById(int id);

        string GetValueByName(string name);

        void Add(SettingDto setting);

        bool Update(int id, SettingDto setting);

        void Delete(int id);
    }
}
