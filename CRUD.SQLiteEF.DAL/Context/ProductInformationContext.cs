using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class ProductInformationContext : DbContext
    {
        public ProductInformationContext(string nameOrConnectionString) :
            base(nameOrConnectionString)
        {
            Configure();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ProductInformationModelConfiguration.Configure(modelBuilder);
            var initializer = new ProductInformationDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
