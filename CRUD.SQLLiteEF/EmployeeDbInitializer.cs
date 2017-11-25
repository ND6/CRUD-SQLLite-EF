using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    public class EmployeeDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<EmployeeContext>
    {
        public EmployeeDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        {
            
        }

        protected override void Seed(EmployeeContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}
