using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace ShoddyWorks.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerServices(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)=>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ShoddyWorksContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
    }
}
