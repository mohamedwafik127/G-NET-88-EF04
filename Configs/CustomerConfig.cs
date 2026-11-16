using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using NationalBank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.Address)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.DateOfBirth)
                   .IsRequired();

            builder.Property(c => c.CustomerType)
                   .IsRequired();

            builder.Property(c => c.NationalId)
                   .IsRequired();
        }
    }
}
