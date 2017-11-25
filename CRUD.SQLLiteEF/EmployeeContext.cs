using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(string nameOrConnectionString) :
            base(nameOrConnectionString)
        {
            Configure();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<EmployeeContext>(modelBuilder);

            //modelBuilder.Entity<EmployeeMaster>().ToTable("EmployeeMaster");

            ModelConfiguration.Configure(modelBuilder);
            var initializer = new EmployeeDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

       // public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
    }
}
