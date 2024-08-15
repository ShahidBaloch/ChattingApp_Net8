using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationServics(this IServiceCollection services,IConfiguration config)
        {
            services.AddControllers();

            //Scoped Life time for AddDbContext
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
