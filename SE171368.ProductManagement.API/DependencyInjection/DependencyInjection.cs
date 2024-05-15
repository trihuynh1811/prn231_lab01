using Microsoft.EntityFrameworkCore;
using SE171368.ProductManagement.Repo.Models;
using SE171368.ProductManagement.Repo.UnitOfwork;

namespace SE171368.ProductManagement.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(getConnection()));
            return services;
        }
        public static IServiceCollection addUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfwork, UnitOfwork>();
            return services;
        }

        public static string getConnection()
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
                var str = config["ConnectionStrings:MyStoreDB"];
                return str;
            }
        }
}
