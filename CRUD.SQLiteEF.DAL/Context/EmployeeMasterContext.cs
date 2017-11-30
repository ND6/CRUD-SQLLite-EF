using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class EmployeeMasterContext : DbContext
    {
        public EmployeeMasterContext(string nameOrConnectionString) :
            base(nameOrConnectionString)
        {
            Configure();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<EmployeeContext>(modelBuilder);

            //modelBuilder.Entity<EmployeeMaster>().ToTable("EmployeeMaster");

            EmployeeMasterModelConfiguration.Configure(modelBuilder);
            var initializer = new EmployeeMasterDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
