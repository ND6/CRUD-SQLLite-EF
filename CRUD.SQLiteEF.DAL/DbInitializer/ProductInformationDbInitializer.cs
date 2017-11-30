using SQLite.CodeFirst;
using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class ProductInformationDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<ProductInformationContext>
    {
        public ProductInformationDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        {
            
        }

        protected override void Seed(ProductInformationContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}
