﻿using System;
using Cms.SharedLibrary.Email.Interfaces;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;


namespace Cms.SharedLibrary.Email
{
    public class GmailEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public GmailEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void Send(string toMail, string subject, string body)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = true
            };

            var mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.FromMail, _emailSettings.FromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(new MailAddress(toMail));

            client.Send(mail);
        }
    }
}

