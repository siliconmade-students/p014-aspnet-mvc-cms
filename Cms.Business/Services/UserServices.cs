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
    public interface IUserService
    {
        void SendResetPasswordEmail(string email);
    }

    public class UserService : IUserService
    {
        private readonly IEmailService _emailService;

        public UserService(IEmailService emailService)
        {
            _emailService = emailService;
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

    }

}
