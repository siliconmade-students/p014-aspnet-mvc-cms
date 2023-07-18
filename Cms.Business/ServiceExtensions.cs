using Cms.Data.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
