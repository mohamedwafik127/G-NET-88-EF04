using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code).HasMaxLength(20);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Address)
                   .HasMaxLength(200);

            builder.Property(b => b.PhoneNumber)
                   .HasMaxLength(20);

            builder.HasData(
                new Branch
                {
                    Code = "CAI-01",
                    Name = "Main Branch",
                    Address = "123 Main St, Cairo",
                    PhoneNumber = "01235548884",
                    ManagerId = 1
                },
                new Branch
                {
                    Code = "ALX-01",
                    Name = "Alexandria Branch",
                    Address = "102 Main St, Alexandria",
                    PhoneNumber = "0129841284",
                    ManagerId = 2
                }
                );
        }
    }
}
