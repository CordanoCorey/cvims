using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CVIMS.Entity.Auth;
using Microsoft.AspNetCore.Identity;
using CVIMS.Entity.Entities;

namespace CVIMS.Entity.Context
{
    public partial class CVIMSContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public void OnModelCreating_Identity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("AspNetUsers");
            });
            modelBuilder.Entity<ApplicationRole>(e =>
            {
                e.ToTable("AspNetRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("AspNetUserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("AspNetUserLogins");
                e.HasKey(x => new { x.ProviderKey, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("AspNetUserRoles");
                e.HasKey(x => new { x.RoleId, x.UserId });
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("AspNetRoleClaim");
            });

            //TODO-Take anything of value then delete the scaffolder generates code
            #region "Scaffolded Auth"
            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.ToTable("Role", "Auth");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<RoleClaim>(entity =>
            //{
            //    entity.ToTable("RoleClaim", "Auth");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.RoleClaim)
            //        .HasForeignKey(d => d.RoleId)
            //        .HasConstraintName("FK_IdentityRoleClaim_ApplicationRole_RoleId");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User", "Auth");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.LastName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<UserClaim>(entity =>
            //{
            //    entity.ToTable("UserClaim", "Auth");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UserClaim)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_IdentityUserClaim<string>_ApplicationUser_UserId");
            //});

            //modelBuilder.Entity<AspNetUserLogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
            //        .HasName("PK_IdentityUserLogin<string>");

            //    entity.ToTable("UserLogin", "Auth");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(450);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UserLogin)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_IdentityUserLogin<string>_ApplicationUser_UserId");
            //});

            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId })
            //        .HasName("PK_IdentityUserRole");

            //    entity.ToTable("UserRole", "Auth");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.UserRole)
            //        .HasForeignKey(d => d.RoleId)
            //        .HasConstraintName("FK_IdentityUserRole<string>_ApplicationRole_RoleId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UserRole)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_IdentityUserRole<string>_ApplicationUser_UserId");
            //});
            #endregion
        }
    }
}
