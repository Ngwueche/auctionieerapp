using AuctionService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AuctionieerApp.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ServiceExtentions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
