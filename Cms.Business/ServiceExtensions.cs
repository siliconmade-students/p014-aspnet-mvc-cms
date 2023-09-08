using Cms.Business.Services;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.SharedLibrary.Email;
using Cms.SharedLibrary.Email.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<IAppoinmentService, AppoinmentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPageService, PageService>();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        public static void SeedDatabase(this IServiceScope scope)
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //db.Database.EnsureDeleted();

            db.Database.EnsureCreated();

            DbSeeder.Seed(db);
        }
    }
}
