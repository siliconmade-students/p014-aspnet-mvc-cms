using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;

namespace Cms.Business.Services
{
	public class SettingService : ISettingService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public SettingService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public List<SettingDto> GetAll()
		{
			var settings = _context.Settings.ToList();
			return _mapper.Map<List<SettingDto>>(settings);
		}

		public string GetValueByName(string name)
		{
			var setting = _context.Settings.Where(e => e.Name == name).FirstOrDefault();
			if (setting != null)
				return setting.Value;

			return "-";
		}
	}
}
