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
    public class CVIMSContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
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

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
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
            var connectionString = configuration.GetConnectionString("seed");
            builder.UseSqlServer(connectionString);
            return new CVIMSContext(builder.Options);
        }
    }
}
