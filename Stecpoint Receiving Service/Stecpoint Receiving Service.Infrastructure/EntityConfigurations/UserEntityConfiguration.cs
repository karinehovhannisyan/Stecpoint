using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stecpoint_Receiving_Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stecpoint_Receiving_Service.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.OrganizationId).HasColumnName("organization_id");
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(50).IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("first_name").HasMaxLength(30).IsRequired();
            builder.Property(u => u.LastName).HasColumnName("last_name").HasMaxLength(30).IsRequired();
            builder.Property(u => u.MiddleName).HasColumnName("middle_name").HasMaxLength(30);
            builder.Property(u => u.PhoneNumber).HasColumnName("phone_number").HasMaxLength(30);
        }
    }
}
