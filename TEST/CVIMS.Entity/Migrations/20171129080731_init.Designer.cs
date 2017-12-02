﻿// <auto-generated />
using CVIMS.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CVIMS.Entity.Migrations
{
    [DbContext(typeof(CVIMSContext))]
    [Migration("20171129080731_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CVIMS.Entity.Auth.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CVIMS.Entity.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CellPhone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DefaultLandingPageId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("SendOrderApprovedEmail");

                    b.Property<bool>("SendOrderCancelledEmail");

                    b.Property<bool>("SendOrderDeniedEmail");

                    b.Property<bool>("SendOrderPickedEmail");

                    b.Property<bool>("SendOrderPlacedEmail");

                    b.Property<bool>("SendOrderShippedEmail");

                    b.Property<int>("StateId");

                    b.Property<string>("StreetAddress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("DefaultLandingPageId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StateId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(10)")
                        .HasDefaultValueSql("'1'");

                    b.Property<Guid?>("FileId");

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastModifiedById");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Constants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Constants");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bcc");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<string>("Cc");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Failed")
                        .HasMaxLength(2000);

                    b.Property<string>("From")
                        .HasMaxLength(250);

                    b.Property<bool>("Sent");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.EmailAttachment_xref", b =>
                {
                    b.Property<int>("EmailId");

                    b.Property<int>("AttachmentId");

                    b.HasKey("EmailId", "AttachmentId");

                    b.HasIndex("AttachmentId");

                    b.ToTable("EmailAttachment_xref");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Favorite", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("ProductId");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeniedById")
                        .HasMaxLength(128);

                    b.Property<string>("DeniedReason")
                        .HasMaxLength(1000);

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<string>("InternalComments")
                        .HasMaxLength(1000);

                    b.Property<string>("LastModifiedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.Property<string>("Location")
                        .HasMaxLength(255);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderNumber");

                    b.Property<DateTime?>("OrderProcessDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId");

                    b.Property<int?>("PhoneExtension");

                    b.Property<string>("PickedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("PickedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeniedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("PickedById");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.OrderStatus_xref", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("CreatedById");

                    b.Property<int>("OrderStatusId");

                    b.HasKey("OrderId", "CreatedDate");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("OrderStatus_xref");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(1000);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Attribute")
                        .HasMaxLength(1000);

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentTypeId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsTaxable");

                    b.Property<string>("LastModifiedById")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("ProductTitle")
                        .HasMaxLength(255);

                    b.Property<int>("QuantityAvailable");

                    b.Property<int>("QuantityInStock");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("money");

                    b.Property<string>("SKU")
                        .HasMaxLength(128);

                    b.Property<decimal>("Sale")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<decimal?>("SalePrice")
                        .HasColumnType("money");

                    b.Property<bool>("SchoolStore");

                    b.Property<int>("SizeId");

                    b.Property<bool>("StaffStore");

                    b.Property<string>("UPC")
                        .HasMaxLength(255);

                    b.Property<string>("UPC2")
                        .HasMaxLength(255);

                    b.Property<string>("VendorName")
                        .HasMaxLength(255);

                    b.Property<string>("WarehouseLocation")
                        .HasMaxLength(1000);

                    b.Property<string>("WebKeywords")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DepartmentTypeId");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("SizeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte[]>("FileBinary")
                        .IsRequired();

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<long>("FileSize");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.ProductLookupValue_xref", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("LookupValueId");

                    b.HasKey("ProductId", "LookupValueId");

                    b.HasIndex("LookupValueId");

                    b.ToTable("ProductLookupValue_xref");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.DepartmentType_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("DepartmentType_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.EmailType_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("EmailType_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.LandingPage_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("LandingPage_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.Location_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("Location_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.LookupValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<int>("LookupId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort");

                    b.HasKey("Id");

                    b.HasIndex("LookupId");

                    b.ToTable("LookupValue");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.OrderStatus_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.ShippingOptions_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("ShippingOptions_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.Size_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("Size_lkp");
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.State_lkp", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("State_lkp");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("ProviderKey");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ProviderKey", "LoginProvider");

                    b.HasAlternateKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasAlternateKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CVIMS.Entity.Auth.ApplicationUser", b =>
                {
                    b.HasOne("CVIMS.Entity.Lookup.LandingPage_lkp", "DefaultLandingPage")
                        .WithMany()
                        .HasForeignKey("DefaultLandingPageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Lookup.State_lkp", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Attachment", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("AttachmentCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Attachment_ApplicationUser_CreatedBy");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "LastModifiedBy")
                        .WithMany("AttachmentLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Attachment_ApplicationUser_LastModifiedBy");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.CartItem", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany("CartItems")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CVIMS.Entity.Entities.Order", "Order")
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Cart_Order");

                    b.HasOne("CVIMS.Entity.Entities.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Cart_Product")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Category", b =>
                {
                    b.HasOne("CVIMS.Entity.Lookup.Location_lkp", "Location")
                        .WithMany("Categories")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Category_Location_lkp")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Email", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("EmailCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Email_ApplicationUser_CreatedBy");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.EmailAttachment_xref", b =>
                {
                    b.HasOne("CVIMS.Entity.Entities.Attachment", "Attachment")
                        .WithMany("Email")
                        .HasForeignKey("AttachmentId")
                        .HasConstraintName("FK_EmailAttachment_xref_Attachment")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Entities.Email", "Email")
                        .WithMany("Attachments")
                        .HasForeignKey("EmailId")
                        .HasConstraintName("FK_EmailAttachment_xref_Email")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Favorite", b =>
                {
                    b.HasOne("CVIMS.Entity.Entities.Product", "Product")
                        .WithMany("Favorites")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Favorite_Product")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Favorite_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Order", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("OrderCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Order_ApplicationUser_CreatedBy");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "DeniedBy")
                        .WithMany("OrderDeniedBy")
                        .HasForeignKey("DeniedById")
                        .HasConstraintName("FK_Order_ApplicationUser_DeniedBy");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "LastModifiedBy")
                        .WithMany("OrderLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Order_ApplicationUser_LastModifiedBy");

                    b.HasOne("CVIMS.Entity.Lookup.OrderStatus_lkp", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "PickedBy")
                        .WithMany("OrderPickedBy")
                        .HasForeignKey("PickedById")
                        .HasConstraintName("FK_Order_ApplicationUser_PickedBy");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Order_ApplicationUser");
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.OrderStatus_xref", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany("OrderStatusChanges")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("OrderStatusCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_OrderStatus_xref_ApplicationUser_CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Entities.Order", "Order")
                        .WithMany("OrderStatusChanges")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderStatus_xref_Order")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Lookup.OrderStatus_lkp", "OrderStatus")
                        .WithMany("OrderStatuses")
                        .HasForeignKey("OrderStatusId")
                        .HasConstraintName("FK_OrderStatus_xref_OrderStatus_lkp")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.Product", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany("Products")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CVIMS.Entity.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("ProductCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_Product_ApplicationUser_CreatedBy");

                    b.HasOne("CVIMS.Entity.Lookup.DepartmentType_lkp", "DepartmentType")
                        .WithMany()
                        .HasForeignKey("DepartmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "LastModifiedBy")
                        .WithMany("ProductLastModifiedBy")
                        .HasForeignKey("LastModifiedById")
                        .HasConstraintName("FK_Product_ApplicationUser_LastModifiedBy");

                    b.HasOne("CVIMS.Entity.Lookup.Size_lkp", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.ProductImage", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany("ProductImage")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser", "CreatedBy")
                        .WithMany("ProductImageCreatedBy")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK_ProductImage_ApplicationUser_CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CVIMS.Entity.Entities.Product", "Product")
                        .WithMany("ProductImage")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductImage_Product")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CVIMS.Entity.Entities.ProductLookupValue_xref", b =>
                {
                    b.HasOne("CVIMS.Entity.Lookup.LookupValue", "LookupValue")
                        .WithMany("Products")
                        .HasForeignKey("LookupValueId")
                        .HasConstraintName("FK_ProductLookupValue_xref_LookupValue")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Entities.Product", "Product")
                        .WithMany("LookupValues")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductLookupValue_xref_Product")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVIMS.Entity.Lookup.LookupValue", b =>
                {
                    b.HasOne("CVIMS.Entity.Lookup.Lookup", "Lookup")
                        .WithMany("LookupValues")
                        .HasForeignKey("LookupId")
                        .HasConstraintName("FK_LookupValue_xref_Lookup")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CVIMS.Entity.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
