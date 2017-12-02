using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CVIMS.Entity.Auth;
using CVIMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using CVIMS.Entity.Lookup;

namespace CVIMS.Entity.Context
{
    //Create a Read Only context with ApplicationIntent Readonly in the connectionstring.
    //It's faster for gets and will automatically be sent to secondary nodes in an availability group.
    public partial class CVIMSContextRO : CVIMSContext
    {
        DbContextOptions<CVIMSContextRO> _options2;
        public CVIMSContextRO(DbContextOptions<CVIMSContext> options, DbContextOptions<CVIMSContextRO> options2) : base(options)
        {
            _options2 = options2;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options2.FindExtension<Microsoft.EntityFrameworkCore.Infrastructure.Internal.SqlServerOptionsExtension>().ConnectionString);
        }
    }
    public partial class CVIMSContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public CVIMSContext(DbContextOptions<CVIMSContext> options) : base(options)
        { }
        public DbSet<Constants> Constants { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.OnModelCreating_Identity(modelBuilder);
            this.OnModelCreating_Lookup(modelBuilder);
            
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentName)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime2");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("1");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsPrivate).HasDefaultValueSql("0");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime2");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AttachmentCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Attachment_ApplicationUser_CreatedBy");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AttachmentLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Attachment_ApplicationUser_LastModifiedBy");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Cart_Product");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Cart_Order");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(e => e.Label).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Category_Location_lkp");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedById).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime2");

                entity.Property(e => e.Failed).HasMaxLength(2000);

                entity.Property(e => e.From).HasMaxLength(250);

                entity.Property(e => e.SentDate).HasColumnType("datetime2");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.To).IsRequired();

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.EmailCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Email_ApplicationUser_CreatedBy");
            });

            modelBuilder.Entity<EmailAttachment_xref>(entity =>
            {
                entity.HasKey(x => new { x.EmailId, x.AttachmentId });

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailAttachment_xref_Email");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.AttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailAttachment_xref_Attachment");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.ProductId });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorite_User");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorite_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id); entity.Property(e => e.CreatedById).HasMaxLength(128);

                entity.Property(e => e.OrderDate).HasColumnType("datetime2");

                entity.Property(e => e.OrderProcessDate).HasColumnType("datetime2");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.InternalComments).HasMaxLength(1000);

                entity.Property(e => e.DeniedById).HasMaxLength(128);

                entity.Property(e => e.DeniedReason).HasMaxLength(1000);

                entity.Property(e => e.PickedById).HasMaxLength(128);

                entity.Property(e => e.PickedDate).HasColumnType("datetime2");

                entity.Property(e => e.CreatedById).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime2");

                entity.Property(e => e.LastModifiedById).HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_ApplicationUser");

                entity.HasOne(d => d.DeniedBy)
                    .WithMany(p => p.OrderDeniedBy)
                    .HasForeignKey(d => d.DeniedById)
                    .HasConstraintName("FK_Order_ApplicationUser_DeniedBy");

                entity.HasOne(d => d.PickedBy)
                    .WithMany(p => p.OrderPickedBy)
                    .HasForeignKey(d => d.PickedById)
                    .HasConstraintName("FK_Order_ApplicationUser_PickedBy");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.OrderCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Order_ApplicationUser_CreatedBy");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.OrderLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Order_ApplicationUser_LastModifiedBy");
            });

            modelBuilder.Entity<OrderStatus_xref>(entity =>
            {
                entity.HasKey(x => new { x.OrderId, x.CreatedDate });

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderStatusChanges)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderStatus_xref_Order");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderStatuses)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderStatus_xref_OrderStatus_lkp");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.OrderStatusCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderStatus_xref_ApplicationUser_CreatedBy");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(e => e.ProductTitle).HasMaxLength(255);

                entity.Property(e => e.ProductDescription).HasMaxLength(1000);

                entity.Property(e => e.SKU).HasMaxLength(128);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.RetailPrice).HasColumnType("money");

                entity.Property(e => e.SalePrice).HasColumnType("money");

                entity.Property(e => e.Sale).HasDefaultValueSql("0");

                entity.Property(e => e.AdditionalInfo).HasMaxLength(1000);

                entity.Property(e => e.UPC).HasMaxLength(255);

                entity.Property(e => e.UPC2).HasMaxLength(255);

                entity.Property(e => e.VendorName).HasMaxLength(255);

                entity.Property(e => e.Attribute).HasMaxLength(1000);

                entity.Property(e => e.WarehouseLocation).HasMaxLength(1000);

                entity.Property(e => e.WebKeywords).HasMaxLength(1000);

                entity.Property(e => e.CreatedById).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime2");

                entity.Property(e => e.LastModifiedById).HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime2");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProductCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Product_ApplicationUser_CreatedBy");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProductLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Product_ApplicationUser_LastModifiedBy");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FileBinary).IsRequired();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductImage_Product");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProductImageCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductImage_ApplicationUser_CreatedBy");
            });

            modelBuilder.Entity<ProductLookupValue_xref>(entity =>
            {
                entity.HasKey(x => new { x.ProductId, x.LookupValueId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LookupValues)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLookupValue_xref_Product");

                entity.HasOne(d => d.LookupValue)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.LookupValueId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLookupValue_xref_LookupValue");
            });
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CVIMSContext>
    {
        public CVIMSContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CVIMSContext>();
            var connectionString = configuration.GetConnectionString("cvims");
            builder.UseSqlServer(connectionString);
            return new CVIMSContext(builder.Options);
        }
    }
}
