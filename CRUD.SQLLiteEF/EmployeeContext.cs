﻿using System;
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
        public EmployeeContext() :
            base("SQLLIteWithEF")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeMaster>().ToTable("EmployeeMaster");
        }

        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
    }
}
