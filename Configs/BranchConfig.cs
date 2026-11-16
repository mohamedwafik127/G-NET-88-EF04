using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Address)
                   .HasMaxLength(200);

            builder.Property(b => b.PhoneNumber)
                   .HasMaxLength(20);
        }
    }
}
