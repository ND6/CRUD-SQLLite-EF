using CRUD.SQLiteEF.Entities;
using System.Data.Entity;

namespace CRUD.SQLiteEF.DAL
{
    public class EmployeeMasterModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureEmployeeEntity(modelBuilder);
        }

        private static void ConfigureEmployeeEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeMaster>();
        }
    }

   
}
