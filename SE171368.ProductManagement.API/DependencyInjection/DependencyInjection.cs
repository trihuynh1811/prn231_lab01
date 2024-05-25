using Microsoft.EntityFrameworkCore;
using SE171368.ProductManagement.Repo.Models;
using SE171368.ProductManagement.Repo.UnitOfwork;

namespace SE171368.ProductManagement.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var result = bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var getEnvironmentIsRunningInDockerContainer);
            Console.WriteLine(getEnvironmentIsRunningInDockerContainer);
            if (getEnvironmentIsRunningInDockerContainer != null && getEnvironmentIsRunningInDockerContainer == true)
            {
                Console.WriteLine("yes run in docker");
                services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(getConnection("MyStoreDbDockerRun")));
            }
            else
            {
                Console.WriteLine("run in normal environment");
                services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(getConnection("MyStoreDb")));
            }
            //services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(getConnection("MyStoreDB")));
            return services;
        }
        public static IServiceCollection addUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfwork, UnitOfwork>();
            return services;
        }

        public static string getConnection(string connectionString)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var str = config[$"ConnectionStrings:{connectionString}"];
            return str;
        }
    }
}
