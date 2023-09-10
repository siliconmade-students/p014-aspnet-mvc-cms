using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;
using Cms.SharedLibrary.Email.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services
{

    public class UserService : IUserService
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;


		public UserService(IEmailService emailService,AppDbContext appDbContext, IMapper mapper)
        {
            _emailService = emailService;
			_appDbContext = appDbContext;
            _mapper = mapper;
		}

		public void Add(UserDto user)
		{
            _appDbContext.Users.Add(_mapper.Map<User>(user));
            _appDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
            var user = _appDbContext.Users.Find(id);
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
		}

		public List<UserDto> GetAll()
		{
			return _mapper.Map<List<UserDto>>(_appDbContext.Users.ToList());
		}

        public int GetAllNo()
        {
            return _mapper.Map<List<UserDto>>(_appDbContext.Users.ToList()).Count();
        }

        public UserDto GetById(int id)
		{
			return _mapper.Map<UserDto>(_appDbContext.Users.Find(id));
		}

		public void SendResetPasswordEmail(string email)
        {
            // Activation Email
            var mailLink = "https://localhost:7018/Auth/ResetPassword/?EmailAddress=" + email;

            _emailService.Send(email, "Hospital - Reset Password", @$"
                <style>body {{ font-family: Arial; font-size: 16px; }}</style>
                <h1>Hospital</h1>
                <p>Please click the link below and reset your password.</p>
                <p><a href='{mailLink}'>Aktive Et</a>
            ");
        }

		public bool Update(int id,UserDto user)
		{
            var a = _appDbContext.Users.Find(id);
            if (a == null) return false;

            a.Surname = user.Surname;
            a.Email = user.Email;   
            a.Password = user.Password;
            a.Phone = user.Phone;
            a.Name = user.Name;
            a.City = user.City;
            _appDbContext.SaveChanges();
            return true;
		}
	}

}
