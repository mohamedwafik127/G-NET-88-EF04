using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(b => b.AccountNumber);

            builder.Property(a => a.AccountNumber).HasMaxLength(20);

            builder.Property(b => b.CurrentBalance)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(b => b.AccountType)
                   .IsRequired();

            builder.Property(b => b.OpeningDate)
                   .IsRequired();

            builder.HasOne(b => b.Branch)
                   .WithMany(b => b.Accounts)
                   .HasForeignKey(b => b.BranchCode)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
