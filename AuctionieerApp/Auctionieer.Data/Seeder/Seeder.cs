using AuctionService.Data.Context;
using AuctionService.Domain.Constants;
using AuctionService.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionService.Data.Seeder;

public static class Seeder
{
    public static async Task Run(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
            await context.Database.MigrateAsync();

        if (!context.Roles.Any())
        {
            var roles = new List<IdentityRole>
            {
                new()  { Name = RoleConstants.User, NormalizedName = RoleConstants.User},
                new()  { Name = RoleConstants.Admin, NormalizedName = RoleConstants.Admin }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
            var userManager = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<UserManager<User>>();
            var user = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                PhoneNumber = "080123456789"
            };
            await userManager.CreateAsync(user, "Admin@123");
            await userManager.AddToRoleAsync(user, RoleConstants.Admin);
            var config = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<IConfiguration>();
            var dataGenerator = new DbSeederGenerator(context, userManager);
            await dataGenerator.Run();
        }
    }
}