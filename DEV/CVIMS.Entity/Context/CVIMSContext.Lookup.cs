using CVIMS.Entity.Auth;
using CVIMS.Entity.Lookup;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Context
{
    public partial class CVIMSContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public void OnModelCreating_Lookup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CVIMS.Entity.Lookup.Lookup>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Label).HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<LookupValue>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Lookup)
                    .WithMany(p => p.LookupValues)
                    .HasForeignKey(d => d.LookupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_LookupValue_xref_Lookup");
            });

            modelBuilder.Entity<DepartmentType_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<EmailType_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.Property(e => e.Label).HasMaxLength(255);
            });

            modelBuilder.Entity<LandingPage_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.Property(e => e.Label).HasMaxLength(255);
            });

            modelBuilder.Entity<Location_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<OrderStatus_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ShippingOptions_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.Property(e => e.Label).HasMaxLength(255);
            });

            modelBuilder.Entity<Size_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<State_lkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.Property(e => e.Label).HasMaxLength(255);
            });
        }
    }
}
