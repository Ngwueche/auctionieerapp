using AuctionService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionService.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuditTrail> AuditTrailes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}