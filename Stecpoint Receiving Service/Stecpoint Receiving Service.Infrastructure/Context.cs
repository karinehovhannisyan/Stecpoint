using Microsoft.EntityFrameworkCore;
using Stecpoint_Receiving_Service.Domain.Models;
using Stecpoint_Receiving_Service.Infrastructure.EntityConfigurations;

namespace Stecpoint_Receiving_Service.Infrastructure
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationEntityConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
