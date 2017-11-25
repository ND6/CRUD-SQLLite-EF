using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    public class ModelConfiguration
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
