using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;

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

        public void Add(SettingDto setting)
        {
			_context.Settings.Add(_mapper.Map<Setting>(setting));
			_context.SaveChanges();
        }

        public void Delete(int id)
        {
			_context.Remove(_context.Settings.Find(id));
			_context.SaveChanges();
        }

        public List<SettingDto> GetAll()
		{
			var settings = _context.Settings.ToList();
			return _mapper.Map<List<SettingDto>>(settings);
		}
        public SettingDto GetById(int id)
        {
            var setting = _context.Settings.Find(id);
            return _mapper.Map<SettingDto>(setting);
        }

        public string GetValueByName(string name)
		{
			var setting = _context.Settings.Where(e => e.Name == name).FirstOrDefault();
			if (setting != null)
				return setting.Value;

			return "-";
		}

        public bool Update(int id, SettingDto setting)
        {
			var oldSetting = _context.Settings.Find(id);
            if(oldSetting == null) return false;
			oldSetting.Name = setting.Name;
			oldSetting.Value = setting.Value;
			_context.SaveChanges();
			return true;
        }
    }
}
