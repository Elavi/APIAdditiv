using CustomerAPI.DAL.Entities;
using CustomerAPI.DAL.EntityFramework.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CustomerAPI.DAL.EntityFramework
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("Customer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerContext, Configuration>());
            Database.Initialize(false);
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
