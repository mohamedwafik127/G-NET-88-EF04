using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    internal class ManagerConfig : IEntityTypeConfiguration<Manager>
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
        }
    }
}
