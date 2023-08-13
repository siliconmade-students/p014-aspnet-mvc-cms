using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cms.SharedLibrary.Email;
using Cms.SharedLibrary.Email.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                // appSettings.json içerisindeki Default bağlantı metnini almayı sağlar.
                string connectionString = configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
            });
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPostService, PostService>();

            if (configuration["App:MailServer"] == "Smtp")
            {
                services.AddSingleton<IEmailService, SmtpEmailService>();
            }
            else if (configuration["App:MailServer"] == "Gmail")
            {
                services.AddSingleton<IEmailService, GmailEmailService>();
            }
            else if (configuration["App:MailServer"] == "MailTrap")
            {
                services.AddSingleton<IEmailService, MailTrapEmailService>();
            }
            else
            {
                services.AddSingleton<IEmailService, MailTrapEmailService>();
            }

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IUserService, UserService>();
        }



        public static void EnsureCreated(this IServiceScope scope)
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.EnsureDeleted();

            db.Database.EnsureCreated();

            DbSeeder.Seed(db);
        }
    }
}
