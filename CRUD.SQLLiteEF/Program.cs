﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            EmployeeMaster employee = new EmployeeMaster()
            {
                EmpName = "Dika",
                Salary = 1000000
            };

            int rowAffected =  context.Database.ExecuteSqlCommand("DELETE FROM EmployeeMaster");
            Console.WriteLine(string.Format("{0} row Deleted", rowAffected));

            //Create
            context.EmployeeMaster.Add(employee);
            context.SaveChanges();

            Console.WriteLine("Record After Insert :");
            var data = context.EmployeeMaster.ToList();
            DisplayData(data);

            var empUpdate = context.EmployeeMaster.Single(x => x.ID == 1);
            empUpdate.EmpName = "Arta";

            //Update
            context.EmployeeMaster.Attach(empUpdate);
            context.Entry(empUpdate).State = EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("Record After Update :");
            data = context.EmployeeMaster.ToList();
            DisplayData(data);

            //Delete
            context.EmployeeMaster.Attach(empUpdate);
            context.Entry(empUpdate).State = EntityState.Deleted;
            context.SaveChanges();

            Console.WriteLine("Record After Delete :");
            data = context.EmployeeMaster.ToList();
            DisplayData(data);

            Console.ReadKey();
        }

        private static void DisplayData(List<EmployeeMaster> data)
        {
            foreach (var item in data)
            {
                Console.Write(string.Format("ID : {0}  Name : {1}  Salary : {2}  {3}", item.ID, item.EmpName, item.Salary, Environment.NewLine));
            }
        }
    }
}
