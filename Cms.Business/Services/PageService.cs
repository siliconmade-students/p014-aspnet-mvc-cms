using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;

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

        //public void Insert(PageDto page)
        //{
        //    _context.Pages.Add(page.);
        //    _context.SaveChanges();
        //}


        

        public void DeleteById(int id)
        {
            var page = _context.Pages.SingleOrDefault(p => p.Id == id);
            if (page != null)
            {
                _context.Pages.Remove(page);
                _context.SaveChanges();
            }
        }

        public bool Update(int id, PageDto page)
        {
            var oldPage = _context.Pages.Find(id);

            if (oldPage is null) return false;

            //oldDepartment = _mapper.Map<Department>(department);
            oldPage.Title = page.Title;
            oldPage.Content = page.Content;
            _context.SaveChanges();

            return true;

          
        }

        public void Delete(int id)
        {
            var page = _context.Pages.Find(id);
            _context.Pages.Remove(page);
            _context.SaveChanges();
            
        }

        void IPageService.Update(int id, PageDto page)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, PageDto page)
        {
            throw new NotImplementedException();
        }
    }
}
