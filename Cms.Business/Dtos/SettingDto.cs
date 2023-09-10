using Cms.Business.Dtos.Abstract;

namespace Cms.Business.Dtos
{
	public class SettingDto : BaseDto
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
}
