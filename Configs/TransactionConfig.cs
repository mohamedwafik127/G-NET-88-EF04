using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NationalBank.Configs
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(b => b.TransactionNumber);

            builder.Property(b => b.TransactionType)
                   .IsRequired();

            builder.Property(b => b.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(b => b.TransactionDate)
                   .IsRequired();

            builder.Property(b => b.Note)
                   .HasMaxLength(200);

            builder.HasOne(b => b.Account)
                   .WithMany(b => b.Transactions)
                   .HasForeignKey(b => b.AccountNumber)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
