using Cms.Business.Dtos;

namespace Cms.Business.Services.Abstract
{
	public interface ISettingService
	{
		List<SettingDto> GetAll();
		string GetValueByName(string name);
	}
}
