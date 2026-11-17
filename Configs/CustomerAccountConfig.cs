using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class CustomerAccountConfig : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(b => new { b.CustomerId, b.AccountNumber });

            builder.HasOne(b => b.Customer)
                   .WithMany(b => b.CustomerAccounts)
                   .HasForeignKey(b => b.CustomerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Account)
                   .WithMany(b => b.CustomerAccounts)
                   .HasForeignKey(b => b.AccountNumber)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
