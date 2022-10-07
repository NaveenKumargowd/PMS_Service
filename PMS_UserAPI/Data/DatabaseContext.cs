using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PMS_UserAPI.Configurations.Entities;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PMS_UserAPI.Data.IdentityModel;

namespace PMS_UserAPI.Data
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IServiceProvider>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("PMSUsers");
            builder.Entity<ApplicationRole>().ToTable("Roles");
            builder.Entity<UserRoles>().ToTable("UserRoles");
            builder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
        public virtual DbSet<PatientDetail> Patients { get; set; }

        public virtual DbSet<PatientAllergy> Allergys { get; set; }

        public virtual DbSet<EmergencyContact> Emergencies { get; set; }
=======
        public DbSet<Notes> Notes { get; set; }
>>>>>>> e065359df20082182afc477e9ae2cedbf6cf7ad5
    }
    //public class YourDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    //{
    //    public DatabaseContext CreateDbContext(string[] args)
    //    {
    //        var dbHost = "localhost";
    //        var dbName = "pmsdb";
    //        var dbPassword = "password_123";
    //        var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";

    //        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
    //        optionsBuilder.UseSqlServer(connectionString);

    //        return new DatabaseContext(optionsBuilder.Options);
    //    }
    //}
}
