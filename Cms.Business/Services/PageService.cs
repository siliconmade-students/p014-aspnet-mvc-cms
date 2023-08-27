using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;

namespace Cms.Business.Services
{
    public class PageService : IPageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PageDto> GetAll()
        {
            var entities = _context.Pages.ToList();

            return _mapper.Map<List<PageDto>>(entities);
        }

        public PageDto GetById(int id)
        {
            var entity = _context.Pages.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<PageDto>(entity);
        }
    }
}
