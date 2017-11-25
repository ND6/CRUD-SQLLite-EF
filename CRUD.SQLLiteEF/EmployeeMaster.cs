using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    //[Table(Name = "EmployeeMaster")]
    public class EmployeeMaster
    {
        //[Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        //[Column(Name = "EmpName", DbType = "VARCHAR")]
        public string EmpName { get; set; }

        //[Column(Name = "Salary", DbType = "DOUBLE")]
        public double Salary { get; set; }
    } 
}
