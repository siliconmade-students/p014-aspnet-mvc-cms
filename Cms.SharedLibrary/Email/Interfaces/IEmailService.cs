using System;
namespace Cms.SharedLibrary.Email.Interfaces
{
    public interface IEmailService
    {
        void Send(string toMail, string subject, string body);
    }
}

