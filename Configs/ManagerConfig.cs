using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(m => m.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(m => m.HireDate)
                   .IsRequired();

            builder.HasOne(m => m.Branch)
                   .WithOne(m => m.Manager)
                   .HasForeignKey<Branch>(m => m.ManagerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
            new Manager
            {
                Id = 1,
                FullName = "Hassan Mahmoud",
                Email = "hassan.mahmoud@nationalbank.com",
                PhoneNumber = "01011111111",
                HireDate = new DateTime(2018, 3, 1)
            },
            new Manager
            {
                Id = 2,
                FullName = "Salma Adel",
                Email = "salma.adel@nationalbank.com",
                PhoneNumber = "01022222222",
                HireDate = new DateTime(2020, 9, 15)
            });
        }
    }
}
