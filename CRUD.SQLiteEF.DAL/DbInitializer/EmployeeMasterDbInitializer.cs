using SQLite.CodeFirst;
using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class EmployeeMasterDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<EmployeeMasterContext>
    {
        public EmployeeMasterDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        {
            
        }

        protected override void Seed(EmployeeMasterContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}
