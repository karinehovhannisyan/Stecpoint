using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stecpoint_Receiving_Service.Domain.Models;

namespace Stecpoint_Receiving_Service.Infrastructure.EntityConfigurations
{
    public class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

            builder.HasMany(o => o.Users).WithOne(u => u.Organization).HasForeignKey(u => u.OrganizationId);

            builder.HasData(
                new Organization { Id = 1, Name = "Nestle" },
                new Organization { Id = 2, Name = "Ferrero Rocher" } // sorry :)
            );
        }
    }
}
